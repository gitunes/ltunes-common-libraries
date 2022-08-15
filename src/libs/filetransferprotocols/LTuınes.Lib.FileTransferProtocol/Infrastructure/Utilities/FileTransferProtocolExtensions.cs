namespace LTuınes.Lib.FileTransferProtocol.Infrastructure.Utilities
{
    internal static class FileTransferProtocolExtensions
    {
        internal static bool CheckTransactionResult(this FtpStatusCode ftpStatusCode)
        {
            return ftpStatusCode.ToInt() >= FtpStatusCode.CommandOK.ToInt() && ftpStatusCode.ToInt() <= FtpStatusCode.PathnameCreated.ToInt();
        }
    }
}
