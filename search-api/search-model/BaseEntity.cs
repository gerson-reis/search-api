using System;

namespace search_model
{
    public class BaseEntity
    {
        public BaseEntity(int id, DateTime createdOn, DateTime changedOn, bool isActiveRegister)
        {
            CreatedOn = DateTime.Now;
            IsActiveRegister = true;
        }

        protected BaseEntity() {}

        public int Id { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ChangedOn { get; private set; }
        public bool IsActiveRegister { get; private set; }
        public void DesactiveRegister()
        {
            IsActiveRegister = false;
        }
    }
}
