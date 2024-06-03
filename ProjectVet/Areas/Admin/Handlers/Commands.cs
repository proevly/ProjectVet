namespace ProjectVet.Areas.Admin.Handlers
{
    public class Commands
    {
        public class OnaylaRandevuCommand
        {
            public Guid Id { get; set; }
        }

        public class ReddetRandevuCommand
        {
            public Guid Id { get; set; }
        }

        public class DuzenleRandevuCommand
        {
            public Guid Id { get; set; }
            public string PetTur { get; set; }
            public string PetCins { get; set; }
            public DateTime RandevuTarih { get; set; }
            public DateTime RandevuSaat { get; set; }
        }
    }

}
