﻿namespace testMapreVisitor.ViewModel
{
    public class UpdateVisitorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public DateTime DateVisit { get; set; } = DateTime.Now;

    }
}
