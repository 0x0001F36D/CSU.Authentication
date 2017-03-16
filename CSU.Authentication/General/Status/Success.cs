namespace CSU.Authentication.General.Status
{
    class Success<R> : IStatus<R>
    {
        public Success(R data)
        {
            this.Data = data;
        }
        

        public bool Status => true; 
         
        public R Data { get; private set; }

        object IStatus.Data => this.Data;
    }

    class Success : IStatus
    {
        public Success()
        {
        }

        public object Data => null;

        public bool Status => true;
        
    }
}
