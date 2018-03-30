using System.Collections.Generic;

namespace ParsingXmlToObjectsManually.Models
{
    public class Cage
    {
        public string Race;
        public string Future;
        public string Chronic;
        public string Pen;
        public string Brake;
        public string Rage;
        public string Slip;
        public List<Judgement> Judgements;

        public Cage(string race, string future, string chronic, string pen, string brake, string rage, string slip, List<Judgement> judgements)
        {
            Race = race;
            Future = future;
            Chronic = chronic;
            Pen = pen;
            Brake = brake;
            Rage = rage;
            Slip = slip;
            Judgements = judgements;
        }
    }
}