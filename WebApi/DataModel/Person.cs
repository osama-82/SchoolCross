using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class Person
    {
        public Person()
        {
            ClassPerson = new HashSet<ClassPerson>();
            MessagesFromPerson = new HashSet<Messages>();
            MessagesToPerson = new HashSet<Messages>();
            ParentChildChildPerson = new HashSet<ParentChild>();
            ParentChildParentPerson = new HashSet<ParentChild>();
            PersonAbsences = new HashSet<PersonAbsences>();
            StudentCurriculumGrade = new HashSet<StudentCurriculumGrade>();
        }

        public int PersonId { get; set; }
        public int EducationalCenterId { get; set; }
        public string WebUserId { get; set; }
        public string DeviceTokenId { get; set; }
        public string ActivationCode { get; set; }
        public int AccountTypeId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string PhotoUrl { get; set; }
        public string PublicPhotoUrl { get; set; }
        public bool? Active { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Deleted { get; set; }
        public string NotificationTokenId { get; set; }
        public string ImportRefId { get; set; }

        public AccountsTypes AccountType { get; set; }
        public EducationalCenters EducationalCenter { get; set; }
        public ICollection<ClassPerson> ClassPerson { get; set; }
        public ICollection<Messages> MessagesFromPerson { get; set; }
        public ICollection<Messages> MessagesToPerson { get; set; }
        public ICollection<ParentChild> ParentChildChildPerson { get; set; }
        public ICollection<ParentChild> ParentChildParentPerson { get; set; }
        public ICollection<PersonAbsences> PersonAbsences { get; set; }
        public ICollection<StudentCurriculumGrade> StudentCurriculumGrade { get; set; }
    }
}
