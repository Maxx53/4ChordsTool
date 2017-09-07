using MidiSharp;
using MidiSharp.Events;
using MidiSharp.Events.Meta;
using MidiSharp.Events.Meta.Text;
using MidiSharp.Events.Voice.Note;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ChordsTool
{
    class MidiReader
    {
        public float Tempo { get; set; }
        public string TrackName { get; set; }

        private static float tickDuration = 0f;
        private static float noteDuration = 0f;
        private List<Pitch[]> chordsTrack = new List<Pitch[]>();
        private List<Pitch> melodyTrack = new List<Pitch>();
        private List<bool> snaresTrack = new List<bool>();
        private List<bool> hihatsTrack = new List<bool>();

        public MidiReader(string fileName)
        {
            using (Stream inputStream = File.OpenRead(fileName))
            {
                MidiSequence sequence = MidiSequence.Open(inputStream);
                ReadHeader(sequence.Tracks[0]);

                tickDuration = 60000f / (Tempo * (float)sequence.Division);
                noteDuration = 15000f / Tempo;

                ReadChordsTrack(sequence.Tracks[1]);
                ReadMelodyTrack(sequence.Tracks[2]);

                ReadDrum(sequence.Tracks[3], 38, snaresTrack);
                ReadDrum(sequence.Tracks[3], 44, hihatsTrack);
            }
        }

        private void ReadHeader(MidiTrack midiTrack)
        {
            foreach (MidiEvent ev in midiTrack.Events)
            {
                var tempoMeta = ev as TempoMetaMidiEvent;
                if (tempoMeta != null)
                {
                    Tempo = 60000000f / tempoMeta.Value;
                }

                var nameMeta = ev as SequenceTrackNameTextMetaMidiEvent;
                if (nameMeta != null)
                {
                    TrackName = nameMeta.Text;
                }
            }
        }

        public List<string> GetChords()
        {
            var resList = new List<string>();

            foreach (var chord in chordsTrack)
            {
                resList.Add(chord[0].GetDisplayName());

            }
            return resList;
        }

        public List<Pitch> GetMelody()
        {
            return melodyTrack;
        }

        public List<bool> GetHihats()
        {
            return hihatsTrack;
        }

        public List<bool> GetSnares()
        {
            return snaresTrack;
        }
  
   
        private static void ReadDrum(MidiTrack midiTrack, byte drum, List<bool> input)
        {
            bool drumAdded = false;

            foreach (MidiEvent ev in midiTrack.Events)
            {
                NoteVoiceMidiEvent nvme = ev as NoteVoiceMidiEvent;

                if (nvme != null)
                {
                    var ms = (int)((float)nvme.DeltaTime * tickDuration);
                    var tickCount = Math.Round(ms / noteDuration);

                    //NoteON
                    if (nvme.Category == 9)
                    {
                        //Playing
                        if (nvme.DeltaTime == 0)
                        {
                            if (nvme.Note == drum)
                            {
                                input.Add(true);
                                drumAdded = true;
                            }
                        }
                        //Sleeping
                        else
                        {
                            for (int i = 0; i < tickCount; i++)
                            {
                                input.Add(false);
                            }
                        }

                    }
                    else
                    //Note off
                    if (nvme.Category == 8)
                    {
                        var start = 0;
                        if (drumAdded)
                        {
                            start = 1;
                            drumAdded = false;
                        }
                        for (int i = start; i < tickCount; i++)
                        {
                            input.Add(false);
                        }
                    }
                }
            }
        }



        private void ReadChordsTrack(MidiTrack midiTrack)
        {
            byte lastnote = 0;
            bool chordStart = false;
            bool chodAdded = false;
            Pitch[] chord = new Pitch[6];
            int index = 0;
            foreach (MidiEvent ev in midiTrack.Events)
            {
                NoteVoiceMidiEvent nvme = ev as NoteVoiceMidiEvent;

                if (nvme != null)
                {

                    var ms = (int)((float)nvme.DeltaTime * tickDuration);
                    var tickCount = Math.Round(ms / noteDuration);

                    //NoteON
                    if (nvme.Category == 9)
                    {
                        if (chordStart)
                        {
                            if (nvme.DeltaTime == 0)
                            {
                                chord[index] = (Pitch)nvme.Note;
                                // lastnote = nvme.Note;
                            }
                            chordStart = false;
                        }
                        else
                        {
                            chord = new Pitch[6];

                            chord[index] = (Pitch)nvme.Note;

                        }
                        chodAdded = false;
                        index++;
                    }
                    else
                    //Note off
                    if (nvme.Category == 8)
                    {
                        if (!chodAdded)
                        {
                            chordsTrack.Add(chord);
                            chodAdded = true;

                        }
                        index = 0;
                        chordStart = true;

                        for (int i = 1; i < tickCount; i++)
                        {
                            chordsTrack.Add(chord);
                        }
                    }

                }
            }
        }


        private void ReadMelodyTrack(MidiTrack midiTrack)
        {
            byte lastnote = 0;

            foreach (MidiEvent ev in midiTrack.Events)
            {
                NoteVoiceMidiEvent nvme = ev as NoteVoiceMidiEvent;

                if (nvme != null)
                {

                    var ms = (int)((float)nvme.DeltaTime * tickDuration);
                    var tickCount = Math.Round(ms / noteDuration);

                    //NoteON
                    if (nvme.Category == 9)
                    {
                        //Playing
                        if (nvme.DeltaTime == 0)
                        {
                            melodyTrack.Add((Pitch)nvme.Note);
                            lastnote = nvme.Note;
                        }
                        //Sleeping
                        else
                        {
                            for (int i = 0; i < tickCount; i++)
                            {
                                melodyTrack.Add(Pitch.z);
                            }
                            melodyTrack.Add((Pitch)lastnote);
                        }

                    }
                    else
                    //Note off
                    if (nvme.Category == 8)
                    {
                        for (int i = 1; i < tickCount; i++)
                        {
                            melodyTrack.Add(Pitch._);
                        }
                    }
                 
                }
            }
        }

     
    }
}
