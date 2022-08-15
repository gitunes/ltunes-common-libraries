namespace LTuınes.Lib.FileTransferProtocol.Services
{
    public sealed class FileTransferProtocolManager : IFileTransferProtocolService
    {
        private readonly IFtpSetting _ftpSetting;
        private readonly ILogger<FileTransferProtocolManager> _logger;

        public FileTransferProtocolManager(
            IFtpSetting ftpSetting,
            ILogger<FileTransferProtocolManager> logger)
        {
            _ftpSetting = ftpSetting;
            _logger = logger;
        }

        public async Task<IResult> IsDirectoryExistsAsync(string directoryPath)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create($"{_ftpSetting.Url}/{directoryPath}") as FtpWebRequest;
                ftpWebRequest.Credentials = new NetworkCredential(_ftpSetting.Username, _ftpSetting.Password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                using FtpWebResponse ftpWebResponse = await ftpWebRequest.GetResponseAsync() as FtpWebResponse;

                if (!ftpWebResponse.StatusCode.CheckTransactionResult())
                {
                    _logger.LogWarning("{@directoryPath} -- dizin bulunamadı.", directoryPath);
                    return new ErrorResult(ExceptionMessage.DirectoryNotFound);
                }

                return new SuccessResult();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{@directoryPath} -- dizin bulunamadı.", directoryPath);
                return new ErrorResult(ExceptionMessage.DirectoryNotFound);
            }
        }

        public async Task<IResult> CreateDirectoryIfNotExistsAsync(string directoryPath)
        {
            var result = await IsDirectoryExistsAsync(directoryPath);
            if (result.Succeeded)
                return result;

            return await CreateDirectoryAsync(directoryPath);
        }

        public async Task<IResult> CreateDirectoryAsync(string directoryPath)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create($"{_ftpSetting.Url}/{directoryPath}") as FtpWebRequest;
                ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpWebRequest.Credentials = new NetworkCredential(_ftpSetting.Username, _ftpSetting.Password);
                using var ftpWebResponse = await ftpWebRequest.GetResponseAsync() as FtpWebResponse;

                if (!ftpWebResponse.StatusCode.CheckTransactionResult())
                {
                    _logger.LogWarning("{@directoryPath} -- dizin oluşturulamadı.", directoryPath);
                    return new ErrorResult(ExceptionMessage.FailedCreateDirectory);
                }

                return new SuccessResult();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{@directoryPath} -- dizin oluşturulamadı.", directoryPath);
                return new ErrorResult(ExceptionMessage.FailedCreateDirectory);
            }
        }

        public async Task<IResult> DeleteDirectoryAsync(string directoryPath)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create(directoryPath) as FtpWebRequest;
                ftpWebRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftpWebRequest.Credentials = new NetworkCredential(_ftpSetting.Username, _ftpSetting.Password);
                using FtpWebResponse ftpWebResponse = await ftpWebRequest.GetResponseAsync() as FtpWebResponse;

                if (!ftpWebResponse.StatusCode.CheckTransactionResult())
                {
                    _logger.LogWarning("{@directoryPath} dizini silinemedi.", directoryPath);
                    return new ErrorResult(ExceptionMessage.FailedDeleteDirectory);
                }

                return new SuccessResult();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{@directoryPath} dizini silinemedi.", directoryPath);
                return new ErrorResult(ExceptionMessage.FailedDeleteDirectory);
            }
        }

        public async Task<IResponse<string>> GenerateNewFileNameIfExistsFileAsync(string directoryPath, IFormFile formFile)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create($"{_ftpSetting.Url}/{directoryPath}/{formFile.FileName}") as FtpWebRequest;
                ftpWebRequest.Credentials = new NetworkCredential(_ftpSetting.Username, _ftpSetting.Password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                using FtpWebResponse ftpWebResponse = await ftpWebRequest.GetResponseAsync() as FtpWebResponse;

                if (!ftpWebResponse.StatusCode.CheckTransactionResult())
                {
                    _logger.LogInformation("{@directoryPath} dizininde {@fileName} adında dosya bulunamadığı için mevcut dosya ismi kullanılacaktır.", directoryPath, formFile.FileName);
                    return new SuccessResponse<string>(formFile.FileName, ExceptionMessage.FileNotFound);
                }

                return new SuccessResponse<string>(string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(formFile.FileName)), ExceptionMessage.NewFileNameSpecified);
            }
            catch
            {
                _logger.LogInformation("{@directoryPath} dizininde {@fileName} adında dosya var mı? sorgulaması yapılamadı.", directoryPath, formFile.FileName);
                return new SuccessResponse<string>(formFile.FileName, ExceptionMessage.NewFileNameSpecified);
            }
        }

        public async Task<IResponse<string>> UploadFileAsync(string directoryPath, IFormFile formFile, CancellationToken cancellationToken)
        {
            var fileNameResponse = await GenerateNewFileNameIfExistsFileAsync(directoryPath, formFile);

            var ftpWebRequest = WebRequest.Create($"{_ftpSetting.Url}/{directoryPath}/{fileNameResponse.Data}") as FtpWebRequest;
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpWebRequest.Credentials = new NetworkCredential(_ftpSetting.Username, _ftpSetting.Password);
            ftpWebRequest.ContentLength = formFile.Length;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.UsePassive = true;
            ftpWebRequest.KeepAlive = true;

            try
            {
                using Stream stream = await ftpWebRequest.GetRequestStreamAsync();
                await formFile.CopyToAsync(stream, cancellationToken);

                using FtpWebResponse ftpWebResponse = await ftpWebRequest.GetResponseAsync() as FtpWebResponse;
                if (!ftpWebResponse.StatusCode.CheckTransactionResult())
                    return new SuccessResponse<string>($"{_ftpSetting.Domain}/{directoryPath}/{fileNameResponse.Data}", SuccessMessage.TransactionSuccessful);

                _logger.LogWarning("Dosya yükleme işlemi başarısız. Status Code: {@statusCode} Status Description: {@statusDescription}", ftpWebResponse.StatusCode, ftpWebResponse.StatusDescription);

                return new ErrorResponse<string>(ExceptionMessage.FileNotUploaded);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{@fileName} adlı dosya {@directoryPath} dizinine yüklenirken hata oluştu.", formFile.FileName, directoryPath);
                return new ErrorResponse<string>(ExceptionMessage.FileNotUploaded);
            }
        }

        public async Task<IResult> DeleteFileAsync(string directoryPath)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create($"{_ftpSetting.Url}/{directoryPath}") as FtpWebRequest;
                ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpWebRequest.Credentials = new NetworkCredential(_ftpSetting.Username, _ftpSetting.Password);
                using FtpWebResponse ftpWebResponse = await ftpWebRequest.GetResponseAsync() as FtpWebResponse;

                if (!ftpWebResponse.StatusCode.CheckTransactionResult())
                {
                    _logger.LogWarning("{@filePath} yoluna sahip dosya silinemedi.", directoryPath);
                    return new ErrorResult(ExceptionMessage.FailedDeleteFile);
                }

                return new SuccessResult();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{@filePath} yoluna sahip dosya silinemedi.", directoryPath);
                return new ErrorResult(ExceptionMessage.FailedDeleteFile);
            }
        }
    }
}
