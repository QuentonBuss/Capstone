﻿using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; using System.IO;  namespace HomeworkTracker5000 {     class Program     {         //  Quenton Buss         //  Capstone - Homework Tracker         //  CIT110 M/W 8:00         //  09 Dec 2018           //string dataInfo;         static void Main(string[] args)         {             DisplayOpeningScreen();             DisplayMenu();             DisplayClosingScreen();         }         static void DisplayMenu()         {             string dataPath = @"/Users/quentonbuss/Desktop/HomeworkTracker5000/HomeworkTracker5000/Data/Data.csv";             string menuChoice;             bool exiting = false;              #region Initialize OBJs             //initialize              Assignments Qt13 = new Assignments();             Qt13.AssignmentName = "Quick Task 13";             Qt13.CourseName = Assignments.NMCCourses.EET102;             Qt13.DueDate = new DateTime(2018, 12, 05);             Qt13.Score = 100;              Assignments Exam1 = new Assignments();             Exam1.AssignmentName = "Exam 1 of 2";             Exam1.CourseName = Assignments.NMCCourses.MTH121;             Exam1.DueDate = new DateTime(2018, 12, 12);             Exam1.Score = 0;              Assignments Exam2 = new Assignments();             Exam2.AssignmentName = "Exam 2 of 2";             Exam2.CourseName = Assignments.NMCCourses.MTH121;             Exam2.DueDate = new DateTime(2018, 12, 14);             Exam2.Score = 0;             #endregion              //Add Items to list             List<Assignments> assignmentList = new List<Assignments>();             assignmentList.Add(Qt13);             assignmentList.Add(Exam1);             assignmentList.Add(Exam2);              while (!exiting)             {                 DisplayHeader("Main Menu");                  Console.WriteLine("\tA) Display all Homework");                 Console.WriteLine("\tB) Add an Assignment");                 Console.WriteLine("\tC) Delete an Assignment");                 Console.WriteLine("\tD) Edit Assignment");
                Console.WriteLine("\tE) Save Current Assignments");                 Console.WriteLine("\tQ) Quit");                 Console.WriteLine(" ");                 Console.Write("\tEnter Choice:");                 menuChoice = Console.ReadLine();                  switch (menuChoice)                 {                     case "A":                     case "a":                         DisplayHomework(assignmentList);                         break;                      case "B":                     case "b":                         DisplayAddAssignment(assignmentList);                         break;                      case "C":                     case "c":                        DisplayDeleteHomework(assignmentList);                         break;

                    case "D":
                    case "d":                         DisplayEditAssignmentInfo(assignmentList);                         break;                      case "E":                     case "e":                         DisplaySaveToFile(dataPath, assignmentList);                         break;                      case "Q":                     case "q":                         exiting = true;                         break;                      default:                         break;                 }              }          }

        private static void DisplayHomework(List<Assignments> assignmentList)         {             DisplayHeader("Assignments");             string userResponse;             bool assignmentFound = false;              foreach (Assignments assignment in assignmentList)             {                 Console.WriteLine(assignment.AssignmentName);             }             Console.WriteLine();             Console.Write("Enter Assignment to View: ");             userResponse = Console.ReadLine();              foreach (Assignments assignment in assignmentList)             {                 if (assignment.AssignmentName == userResponse)                 {                     assignmentFound = true;                     Console.WriteLine(" ");                     Console.WriteLine("Assignment Name: " + assignment.AssignmentName);                     Console.WriteLine("Course :         " + assignment.CourseName);                     Console.WriteLine("Due Date:        " + assignment.DueDate);                     Console.WriteLine("Score:           " + assignment.Score);                     break;                 }             }              if (!assignmentFound)             {                 Console.WriteLine("Assignment Not Found");             }              DisplayContinuePrompt();         }

        private static void DisplayAddAssignment(List<Assignments> assignmentList)         {              Assignments newAssignments = new Assignments();             DisplayHeader("Add New Assignment");             Console.Write("Enter Assignemnt Name: ");             newAssignments.AssignmentName = Console.ReadLine();              Console.Write("Enter Assignment's Course Name: ");             Enum.TryParse(Console.ReadLine(), out Assignments.NMCCourses nmcCourses);             newAssignments.CourseName = nmcCourses;              Console.Write("Enter Assignment Due Date and Time (yyyy, mm, dd hh:mm:ss AM/PM): ");             DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);             newAssignments.DueDate = dueDate;              Console.Write("Assignment Grade: ");             double.TryParse(Console.ReadLine(), out double score);             newAssignments.Score = score;              assignmentList.Add(newAssignments);              DisplayContinuePrompt();         }

        private static void DisplayDeleteHomework(List<Assignments> assignmentList)         {             DisplayHeader("Delete an Assignment");             string userResponse;             bool assignmentFound = false;              foreach (Assignments assignment in assignmentList)             {                 Console.WriteLine(assignment.AssignmentName);             }             Console.WriteLine();             Console.Write("Enter Name of Assignment to Delete: ");             userResponse = Console.ReadLine();              foreach (Assignments assignment in assignmentList)             {                 if (assignment.AssignmentName == userResponse)                 {                     assignmentList.Remove(assignment);                     Console.WriteLine(" ");                     Console.WriteLine(userResponse + " has been Removed");                     assignmentFound = true;                     break;                 }             }              if (!assignmentFound)             {                 Console.WriteLine("Assignment Not Found");             }              DisplayContinuePrompt();         } 
        private static void DisplayEditAssignmentInfo(List<Assignments> assignmentList)         {             DisplayHeader("Edit an Assignment");             string userResponse;             bool assignmentFound = false;              foreach (Assignments assignment in assignmentList)             {                 Console.WriteLine(assignment.AssignmentName);             }             Console.WriteLine();             Console.Write("Enter Assignment to Edit: ");             userResponse = Console.ReadLine();             Console.WriteLine("");              foreach (Assignments assignment in assignmentList)             {                 if (assignment.AssignmentName == userResponse)                 {                     assignmentFound = true;                     Console.WriteLine("A) " + assignment.AssignmentName);                     Console.WriteLine("B) " + assignment.CourseName);                     Console.WriteLine("C) " + assignment.DueDate);                     Console.WriteLine("D) " + assignment.Score);                     Console.WriteLine("");                     Console.WriteLine("F) Return To Main Menu");                     string propertyChoice;                      bool exiting = false;                      while (!exiting)                      {                         Console.WriteLine("");                         Console.Write("Select A Property to Update:");                          propertyChoice = Console.ReadLine();                          switch (propertyChoice)                          {                              case "A":                             case "a":                                 Console.Write("Enter New Assignment Name: ");                                 assignment.AssignmentName = Console.ReadLine();                                 break;                              case "B":                             case "b":                                 Console.Write("Enter Assignment's New Course Name: ");                                 Enum.TryParse(Console.ReadLine(), out Assignments.NMCCourses nmcCourses);                                 assignment.CourseName = nmcCourses;                                 break;                              case "C":                             case "c":                                 Console.Write("Enter New Assignment Due Date and Time (yyyy, mm, dd hh:mm: ");                                 DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);                                 assignment.DueDate = dueDate;                                 break;                              case "D":                             case "d":                                 Console.Write("New Assignment Grade: ");                                 double.TryParse(Console.ReadLine(), out double score);                                 assignment.Score = score;                                 break;                              case "F":                             case "f":                                 exiting = true;                                 break;                              default:                                 break;                         }                     }                 }             }              if (!assignmentFound)             {                 Console.WriteLine("Monster Not Found");             }              DisplayContinuePrompt();         }          //"Save to CSV" code borrowed from John Velis         private static void DisplaySaveToFile(string dataPath, List<Assignments> assignmentList)
        {             DisplayHeader("Save Assignments to Text");              Console.WriteLine($"\tAssignments will be saved to '{dataPath}'.");             Console.WriteLine("\t\tPress any key to continue.");             Console.ReadKey();              //             // try to write the list of assignments to the file             //             try             {                 WriteCharactersToCsvFile(dataPath, assignmentList);                 Console.WriteLine("\tThe assignments were successfully saved to the file.");             }             catch (Exception e)// catch any exception thrown by the write method             {                 Console.WriteLine("\tThe following error occurred when writing to the file.");                 Console.WriteLine(e.Message);             }              DisplayContinuePrompt();
        }          static void WriteCharactersToCsvFile(string dataPath, List<Assignments> assignmentList)         {             string assignmentString;              List<string> assignmentStringList = new List<string>();              //             // build the list to write to the text file line by line             //             foreach (var assignment in assignmentList)             {                 assignmentString =                     assignment.AssignmentName + "," +                     assignment.CourseName + "," +                     assignment.DueDate + "," +                     assignment.Score;                  assignmentStringList.Add(assignmentString);             }              //             // write the list of strings (characters) to the data file             //             try             {                 File.WriteAllLines(dataPath, assignmentStringList);             }             catch (Exception) // throw any exception up to the calling method             {                 throw;             }          }

        #region Basics         static void DisplayOpeningScreen()         {             Console.BackgroundColor = ConsoleColor.Gray;             Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();              Console.WriteLine();             Console.WriteLine("\t\t\t\tWelcome to");             Console.WriteLine("\t\t\t HOMEWORK TRACKER 5000");             Console.WriteLine();              DisplayContinuePrompt();          }          static void DisplayClosingScreen()         {             Console.Clear();              Console.WriteLine();             Console.WriteLine("\t\tThanks for using");             Console.WriteLine("\t\tHOMEWORK TRACKER 5000");             Console.WriteLine();             Console.WriteLine("\t\tPress any key to exit.");             Console.ReadKey();         }          static void DisplayContinuePrompt()         {             Console.WriteLine();             Console.WriteLine("\t\t\tPress any key to continue.");             Console.ReadKey();         }          static void DisplayHeader(string headerTitle)         {             Console.Clear();             Console.WriteLine();             Console.WriteLine("\t\t" + headerTitle);             Console.WriteLine();         }          #endregion     } }   