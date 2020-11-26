namespace Chinook.Report.Marketing.Models
{
    internal class TrackTime : Contracts.Report.Marketing.ITrackTime
    {
        public string Name { get; set; }

        public int Seconds { get; set; }
    }
}
