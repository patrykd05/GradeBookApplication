using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using Microsoft.VisualBasic;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;

        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int groupSize = (int)Math.Ceiling(Students.Count * 0.2);

            int higher = 0;

            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    higher++;
            }

            if (higher < groupSize)
                return 'A';
            else if (higher < groupSize * 2)
                return 'B';
            else if (higher < groupSize * 3)
                return 'C';
            else if (higher < groupSize * 4)
                return 'D';
            else
                return 'F';


        }
    }      
}
