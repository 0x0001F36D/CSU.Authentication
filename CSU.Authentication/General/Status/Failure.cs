namespace CSU.Authentication.General.Status
{
    using System;

    class Failure : IStatus
    {
        public Failure():this(null)
        {

        }

        public Failure(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public bool Status => false;

        public string ErrorMessage { get; private set; }

        public object Data => null;
    }

    class Failure<R> : IStatus<R>
    {
        public Failure(R data,string errorMessage):this(data)
        {
            this.ErrorMessage = errorMessage;
        }
        public Failure(R data)
        {
            this.Data = data;
        }

        public bool Status => false;

        public string ErrorMessage { get; private set; }

        public R Data { get; private set; }

        object IStatus.Data => this.Data;
    }
}
