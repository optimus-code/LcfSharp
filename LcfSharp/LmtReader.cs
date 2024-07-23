using LcfSharp.Rpg.Audio;
using LcfSharp.Rpg.Maps;
using LcfSharp.Rpg.Shared;
using LcfSharp.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LcfSharp
{
    public enum ChunkEncounterIndex
    {
        TroopId = 0x01
    }

    public enum ChunkMapInfoIndex
    {
        Name = 0x01,
        ParentMap = 0x02,
        Indentation = 0x03,
        Type = 0x04,
        ScrollbarX = 0x05,
        ScrollbarY = 0x06,
        ExpandedNode = 0x07,
        MusicType = 0x0B,
        Music = 0x0C,
        BackgroundType = 0x15,
        BackgroundName = 0x16,
        Teleport = 0x1F,
        Escape = 0x20,
        Save = 0x21,
        Encounters = 0x29,
        EncounterSteps = 0x2C,
        AreaRect = 0x33
    }

    public enum ChunkStartIndex
    {
        PartyMapId = 0x01,
        PartyX = 0x02,
        PartyY = 0x03,
        BoatMapId = 0x0B,
        BoatX = 0x0C,
        BoatY = 0x0D,
        ShipMapId = 0x15,
        ShipX = 0x16,
        ShipY = 0x17,
        AirshipMapId = 0x1F,
        AirshipX = 0x20,
        AirshipY = 0x21
    }

    public class MapInfo
    {
        public DbString Name { get; set; }
        public int ParentMap { get; set; }
        public int Indentation { get; set; }
        public int Type { get; set; }
        public int ScrollbarX { get; set; }
        public int ScrollbarY { get; set; }
        public bool ExpandedNode { get; set; }
        public int MusicType { get; set; }
        public Music Music { get; set; }
        public int BackgroundType { get; set; }
        public DbString BackgroundName { get; set; }
        public int Teleport { get; set; }
        public int Escape { get; set; }
        public int Save { get; set; }
        public List<Encounter> Encounters { get; set; }
        public int EncounterSteps { get; set; }
        public Rect AreaRect { get; set; }


        public MapInfo( LmtReader reader )
        {
            // Read MapInfo fields using the ChunkMapInfoIndex enum
            Name = reader.ReadDbString( ChunkMapInfoIndex.Name );
            ParentMap = reader.ReadInt( ChunkMapInfoIndex.ParentMap );
            Indentation = reader.ReadInt( ChunkMapInfoIndex.Indentation );
            Type = reader.ReadInt( ChunkMapInfoIndex.Type );
            ScrollbarX = reader.ReadInt( ChunkMapInfoIndex.ScrollbarX );
            ScrollbarY = reader.ReadInt( ChunkMapInfoIndex.ScrollbarY );
            ExpandedNode = reader.ReadBool( ChunkMapInfoIndex.ExpandedNode );
            MusicType = reader.ReadInt( ChunkMapInfoIndex.MusicType );
            Music = reader.ReadMusic( ChunkMapInfoIndex.Music );
            BackgroundType = reader.ReadInt( ChunkMapInfoIndex.BackgroundType );
            BackgroundName = reader.ReadDbString( ChunkMapInfoIndex.BackgroundName );
            Teleport = reader.ReadInt( ChunkMapInfoIndex.Teleport );
            Escape = reader.ReadInt( ChunkMapInfoIndex.Escape );
            Save = reader.ReadInt( ChunkMapInfoIndex.Save );
            Encounters = reader.ReadEncounterList( ChunkMapInfoIndex.Encounters );
            EncounterSteps = reader.ReadInt( ChunkMapInfoIndex.EncounterSteps );
            AreaRect = reader.ReadRect( ChunkMapInfoIndex.AreaRect );
        }
    }

    public class LmtReader : IDisposable
    {
        private LcfReader reader;

        public LmtReader( Stream stream )
        {
            reader = new LcfReader( stream );
        }

        private LmtContent ReadLmtContent( LmtHeader header )
        {
            // Read LMT content based on header information
            LmtContent content = new LmtContent( );

            // Example: Read and set content fields from the reader
            content.Data1 = reader.ReadInt( );
            content.Data2 = reader.ReadDouble( );
            // ...

            return content;
        }

        public void Dispose( )
        {
            reader.Dispose( );
        }

        public LmtData ReadLmtData( )
        {
            // Create a class to represent the LMT data structure
            LmtData lmtData = new LmtData( );

            try
            {
                // Read LMT header
                lmtData.Header = ReadLmtHeader( );

                // Read MapInfo based on header information
                lmtData.MapInfo = ReadMapInfo( );

                return lmtData;
            }
            catch ( Exception ex )
            {
                // Handle exceptions or errors
                Console.WriteLine( "Error reading LMT data: " + ex.Message );
                return null;
            }
        }

        private LmtHeader ReadLmtHeader( )
        {
            // Read and parse LMT header information
            LmtHeader header = new LmtHeader( );

            // Example: Read and set header fields from the reader
            header.Version = reader.ReadInt( );
            header.Size = reader.ReadInt( );
            header.Title = reader.ReadString( header.Size );

            return header;
        }

        public MapInfo ReadMapInfo( )
        {
            return new MapInfo( this );
        }

        public DbString ReadDbString( ChunkMapInfoIndex index )
        {
            reader.Seek( OffsetForChunkMapInfoIndex( index ), SeekMode.FromStart );
            DbString dbString = new DbString( );
            dbString.Length = reader.ReadUInt16( );
            dbString.Value = reader.ReadString( dbString.Length );
            return dbString;
        }

        public int ReadInt( ChunkMapInfoIndex index )
        {
            reader.Seek( OffsetForChunkMapInfoIndex( index ), SeekMode.FromStart );
            return reader.ReadInt( );
        }

        public bool ReadBool( ChunkMapInfoIndex index )
        {
            reader.Seek( OffsetForChunkMapInfoIndex( index ), SeekMode.FromStart );
            return reader.ReadBool( );
        }

        public Music ReadMusic( ChunkMapInfoIndex index )
        {
            reader.Seek( OffsetForChunkMapInfoIndex( index ), SeekMode.FromStart );
            Music music = new Music( );
            // Read and populate music fields based on the index
            // Example: music.Field = reader.ReadSomeType(index);
            return music;
        }

        public List<Encounter> ReadEncounterList( ChunkMapInfoIndex index )
        {
            reader.Seek( OffsetForChunkMapInfoIndex( index ), SeekMode.FromStart );
            List<Encounter> encounters = new List<Encounter>( );
            // Read and populate the list of encounters based on the index
            // Example: encounters.Add(ReadEncounter(index));
            return encounters;
        }

        public Rect ReadRect( ChunkMapInfoIndex index )
        {
            reader.Seek( OffsetForChunkMapInfoIndex( index ), SeekMode.FromStart );
            Rect rect = new Rect( );
            // Read and populate rect fields based on the index
            // Example: rect.Field = reader.ReadSomeType(index);
            return rect;
        }
    }

    // Define LMT data structures based on your specific LMT format
    public class LmtHeader
    {
        public int Version { get; set; }
        public int Size { get; set; }
        public string Title { get; set; }
        // Add other header fields as needed
    }

    public class LmtContent
    {
        public int Data1 { get; set; }
        public double Data2 { get; set; }
        // Add other content fields as needed
    }

    public class LmtData
    {
        public LmtHeader Header { get; set; }
        public MapInfo MapInfo { get; set; }
    }
}
