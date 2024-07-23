using LcfSharp.IO;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System.Collections.Generic;

namespace LcfSharp.Rpg.Animations
{
    public enum AnimationChunk : int
    {
        /** String */
        Name = 0x01,
        /** String */
        AnimationName = 0x02,
        /** Battle2 animation when true */
        Large = 0x03,
        /** Array - rpg::AnimationTiming */
        Timings = 0x06,
        /** Integer */
        Scope = 0x09,
        /** Integer */
        Position = 0x0A,
        /** Array - rpg::AnimationFrames */
        Frames = 0x0C
    }

    public enum AnimationScope
    {
        Target = 0,
        Screen = 1
    }

    public enum AnimationPosition
    {
        Up = 0,
        Middle = 1,
        Down = 2
    }

    public class Animation
    {
        public static readonly Dictionary<AnimationScope, string> ScopeTags = new Dictionary<AnimationScope, string>
        {
            { AnimationScope.Target, "target" },
            { AnimationScope.Screen, "screen" }
        };

        public static readonly Dictionary<AnimationPosition, string> PositionTags = new Dictionary<AnimationPosition, string>
        {
            { AnimationPosition.Up, "up" },
            { AnimationPosition.Middle, "middle" },
            { AnimationPosition.Down, "down" }
        };

        public int ID
        {
            get;
            set;
        }

        public DbString Name
        {
            get;
            set;
        }

        public DbString AnimationName
        {
            get;
            set;
        }

        public bool Large
        {
            get;
            set;
        }

        public List<AnimationTiming> Timings
        {
            get;
            set;
        } = [];

        public AnimationScope Scope
        {
            get;
            set;
        }

        public AnimationPosition Position
        {
            get;
            set;
        }

        public List<AnimationFrame> Frames
        {
            get;
            set;
        } = [];

        public Animation(LcfReader reader)
        {
            TypeHelpers.ReadChunks<AnimationChunk>(reader, (chunk) =>
            {
                switch ((AnimationChunk)chunk.ID)
                {
                    case AnimationChunk.Name:
                        Name = reader.ReadDbString(chunk.Length);
                        return true;

                    case AnimationChunk.AnimationName:
                        AnimationName = reader.ReadDbString(chunk.Length);
                        return true;

                    case AnimationChunk.Large:
                        Large = reader.ReadBool();
                        return true;

                    case AnimationChunk.Timings:
                        Timings = new List<AnimationTiming>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Timings.Add(new AnimationTiming(reader));
                        });
                        return true;

                    case AnimationChunk.Scope:
                        Scope =  (AnimationScope)reader.ReadInt();
                        return true;

                    case AnimationChunk.Position:
                        Position = (AnimationPosition)reader.ReadInt();
                        return true;

                    case AnimationChunk.Frames:
                        Frames = new List<AnimationFrame>();
                        TypeHelpers.ReadChunkList(reader, chunk.Length, () =>
                        {
                            Frames.Add(new AnimationFrame(reader));
                        });
                        return true;
                }
                return false;
            });
        }
    }
}