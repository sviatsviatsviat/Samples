<Query Kind="Statements" />

Stream fs = File.Create(@"E:\Work\Mentoring\Mentoring.BCL\mentoring.txt");

fs.Write(new byte[]{56},0,1);

fs.Dispose();