using Domain.Dates;

namespace Domain.User
{
    public class BisnesUsers
    {
        public int Id { get; set; }

        public int UsersId { get; set; }    
        public Users Users { get; set; }
        public int? DatesDrivigsId { get; set; }
        public DatesDrivigs DatesDrivigs { get; set; }
        public  bool StatusAiname { get; set; }= false; // emtehan
        public bool StatusAmali { get; set; }= false;  //age tru bod yani amali ro tamon kardan
        public bool StatusLerningAmali { get; set; }= false; // dore 12 jalase amali
        public bool StatusLerningAiname { get; set; }= false; // class haie ainame ra tamom kardan ya na
    }

}
