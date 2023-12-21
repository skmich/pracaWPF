using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaWPF.classes
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public int Payment { get; set; }
        public string WorkHours { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
        public string Benefits { get; set; }


        public Offer()
        {

        }

        public Offer(int offerId, string title, string position, int payment, string workHours, string responsibilities, string requirements, string benefits)
        {
            this.OfferId = offerId;
            this.Title = title;
            this.Position = position;
            this.Payment = payment;
            this.WorkHours = workHours;
            this.Responsibilities = responsibilities;
            this.Requirements = requirements;
            this.Benefits = benefits;
        }
    }
}
