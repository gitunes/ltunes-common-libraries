namespace LTunes.Lib.Shared.DataTransferObjects.Turkuaz
{
    public sealed class TurkuazResponse<TModel> : IResponse<TModel> where TModel : class, new()
    {
        public Header Header { get; init; }
        public TModel Data { get; init; }
        public bool Succeeded
        {
            get
            {
                if (Header is null || Header?.RetCode is null || Data is null)
                    return false;


                return Header.RetCode.Equals(1);
            }
            set => throw new NotImplementedException();
        }

        public string StatusMessage
        {
            get
            {
                return Header?.Message;
            }
            set => throw new NotImplementedException();
        }
    }

    public sealed record Header
    {
        public int RetCode { get; init; }
        public string Message { get; init; }
        public object RecordInfo { get; init; }
    }
}
