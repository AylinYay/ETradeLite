namespace AppCore.Results.Bases
{
    public abstract class Result
    {
        public bool IsSuccessful { get; } // constructor �zerinden set edilecek.(de�er atanabilir.)
        public string? Message { get; set; }

        protected Result(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
