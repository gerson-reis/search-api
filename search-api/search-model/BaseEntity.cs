using System;

namespace search_model
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedOn = DateTime.Now;
            IsActiveRegister = true;
        }

        public int Id { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ChangedOn { get; private set; }
        public bool IsActiveRegister { get; private set; }
        public void DisableRegister()
        {
            IsActiveRegister = false;
        }
    }
}
