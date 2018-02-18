using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            // There is only one artist in this collection from Mount Vernon, what is their name and age?
            var From_Mt_Vernon_sql = (from artist in Artists where artist.Hometown == "Mount Vernon" select new {artist.ArtistName}).FirstOrDefault();
            Artist From_Mt_Vernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").SingleOrDefault(); // Single or null
            Console.WriteLine($"The Artist from Mt Vernon is {From_Mt_Vernon.ArtistName}. Age: {From_Mt_Vernon.Age}");
            
            // Who is the youngest artist in our collection of artists?
            var Youngest_sql = (from artist in Artists orderby artist.Age select new {artist.ArtistName}).FirstOrDefault();
            Artist Youngest = Artists.FirstOrDefault(artist => artist.Age == Artists.Min(a => a.Age)); // Only selects the first "youngest" Artist
            Console.WriteLine($"The youngest Artist is {Youngest.ArtistName}");
            
            // Just testing code below..
            List<Artist> YoungestAsc = Artists.OrderBy(artist => artist.Age).ToList(); // Just a list of artists ordered by Age
            // var YoungestArtists = Artists.Where(artist => artist.Age == Artists.Min(a => a.Age));
            // Console.WriteLine($"The youngest Artist is {YoungestArtists.FirstOrDefault().ArtistName}");
            List<Artist> YoungestArtists = Artists.Where(artist => artist.Age == Artists.Min(a => a.Age)).ToList();
            // Console.WriteLine($"The youngest Artist is {YoungestArtists.FirstOrDefault().ArtistName}");
            
            // Display all artists with 'William' somewhere in their real name
            var Williams = Artists.Where(artist => artist.RealName.Contains("William")); // Returns [IEnumerable]
            List<Artist> WilliamsToo = Artists.Where(artist => artist.RealName.Contains("William")).ToList(); // Returns [List]
            Console.WriteLine($"Artists that have 'William' in their name are:");
            foreach(var artist in WilliamsToo){
                Console.WriteLine(artist.ArtistName + " - " + artist.RealName);
            }

            //Display the 3 oldest artist from Atlanta
            var OldestAtlantaArtists = Artists.OrderByDescending(artist => artist.Age).Where(artist => artist.Hometown == "Atlanta").Take(3);
            Console.WriteLine($"The 3 oldest artists in Atlanta are:");
            foreach(var artist in OldestAtlantaArtists){
                Console.WriteLine(artist.ArtistName + " - Age: " + artist.Age);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var GroupsNotInNYC = Artists // Returns IEnumerable<string> into var. We could also use "List<string> and cast ToString() at the end".
                            .Where(artist => (artist.Hometown != "New York City")) // Filter down to artists whose Hometown is not NYC
                            .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => {artist.Group = group; return artist;}) // Last part defines how we are using the matching objects values, and what we're returning.
                            .Select(artist => artist.Group.GroupName) // Only select(list) the GroupName values
                            .Distinct(); // Get rid of duplicate values to condense the list
            Console.WriteLine($"The groups that don't have members from NYC are:");
            foreach(var groupName in GroupsNotInNYC){
                Console.WriteLine(groupName);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Group WuTangClan = Groups.Where(group => group.GroupName == "Wu-Tang Clan") // Filtering the Groups list further before joining the Artists list
                                    .GroupJoin(Artists, group => group.Id, artist => artist.GroupId, (group, artist) => {group.Members = artist.ToList(); return group;}).SingleOrDefault(); 
            Console.WriteLine($"The Wu-Tang Clan artists are:");
            foreach(var artist in WuTangClan.Members){
                Console.WriteLine(artist.ArtistName);
            }
        }
    }
}
