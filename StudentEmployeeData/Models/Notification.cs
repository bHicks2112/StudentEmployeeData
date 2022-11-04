using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class Notification
    {
        public List<NotificationItem> Items {get ; set;} = new List<NotificationItem>(); 
        // e-form not submitted notification 
        foreach (var item in Employee)
        {
            if ((item.employee.SubmittedEForm == 'no') && (DateTime.Today > Convert.ToDateTime(item.employee.AuthorizationToWorkEmailSentDate).AddDays(7)) {
                Items.Add(new NotificationItem
                {
                    Type = 'E-form not submitted'
                    Message = 'This student has not submitted their e-form.'
                    EmployeeId = item.EmployeeId
                })
            })
        }
// increase pay rate notification
        foreach (var item in Employee)
        {
            if (Datetime.Today > Convert.ToDateTime(item.employee.IncreaseInputDate).AddMonths(4) {
                Items.Add(new NotificationItem
                {
                    Type = 'Pay Increase'
                    Message = 'Increase pay rate.'
                    EmployeeId = item.EmployeeId
                })
            } ) 
    }
            foreach (var item in Employee)
        {
            if ((item.employee.AuthorizationToWorkReceived == 'No') && (DateTime.Today > Convert.ToDateTime(item.employee.EFormSubmissionDate).AddDays(7)) {
                Items.Add(new NotificationItem
                {
                    Type = 'Authorization to Work'
                    Message = 'Reminder to follow up with student about authorization to work.'
                    EmployeeId = item.EmployeeId
                })
            } ) 
    }

    public class NotificationItem
    {
        [Key]
        [Required]
        public int NotificationId { get; set; }
        public int Type { get; set; }  //pay increase, not authorized to work, e-form not submitted
        public string Message { get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}
