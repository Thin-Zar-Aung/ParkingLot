using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.EntryExitControl
{
    public class GateManager
    {
        private List<EntryGate> entryGates;
        private List<ExitGate> exitGates;
        public GateManager() {
            entryGates = new List<EntryGate>();
            exitGates = new List<ExitGate>();
        }
        public void AddEntryGate(EntryGate entryGate)
        {
            entryGates.Add(entryGate);
        }
        public void AddExitGate(ExitGate exitGate)
        {
            exitGates.Add(exitGate);
        }
        public int GetTotalGates()
        {
            return entryGates.Count + exitGates.Count;
        }

        public int GetEntryGateCount()
        {
            return entryGates.Count;
        }

        public int GetExitGateCount()
        {
            return exitGates.Count;
        }



    }
}
