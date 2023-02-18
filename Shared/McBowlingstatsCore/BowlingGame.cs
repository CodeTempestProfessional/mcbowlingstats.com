using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McBowlingstatsCore
{
    [FirestoreData]
    public class BowlingGame
    {
        [FirestoreProperty]
        public DateTime DateTime { get; set; }
        [FirestoreProperty]
        public string BowlingAlleyName { get; set; } = string.Empty;
        [FirestoreProperty]
        public List<Frame> Frames { get; set; } = new List<Frame>();
        [FirestoreProperty]
        public string PayeeUserID { get; set; } = string.Empty;

    }

    [FirestoreData]
    public record Frame 
    {
        [FirestoreProperty]
        public string UserID { get; set; }
        [FirestoreProperty]
        public List<int> SubFrames { get; set; } = new List<int>();
        [FirestoreProperty]
        public int ExtraPoints { get; set; }
        [FirestoreProperty]
        public int FrameNumber { get; set; }

    }
}
