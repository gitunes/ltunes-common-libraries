namespace LTuınes.Lib.FileTransferProtocol.Services
{
    public partial interface IFileTransferProtocolService : IScopedService
    {
        /// <summary>
        /// Is directory exists
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <returns>type of result interface</returns>
        Task<IResult> IsDirectoryExistsAsync(string directoryPath);

        /// <summary>
        /// Craete directory if not exists
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <returns>type of result interface</returns>
        Task<IResult> CreateDirectoryIfNotExistsAsync(string directoryPath);

        /// <summary>
        /// Create directory
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <returns>type of result interface</returns>
        Task<IResult> CreateDirectoryAsync(string directoryPath);

        /// <summary>
        /// Delete directory
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <returns>type of result interface</returns>
        Task<IResult> DeleteDirectoryAsync(string directoryPath);

        /// <summary>
        /// Is file exists
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <param name="fileName">file name</param>
        /// <returns>type of result interface</returns>
        Task<IResponse<string>> GenerateNewFileNameIfExistsFileAsync(string directoryPath, IFormFile formFile);

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <param name="formFile">form file interface</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>type of file url</returns>
        Task<IResponse<string>> UploadFileAsync(string directoryPath, IFormFile formFile, CancellationToken cancellationToken);

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <returns>type of result interface</returns>
        Task<IResult> DeleteFileAsync(string directoryPath);
    }
}
