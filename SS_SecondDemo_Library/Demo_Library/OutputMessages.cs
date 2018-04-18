using System;

namespace Demo_Library
{
    public static class OutputMessages
    {
        public static string LibraryManagementHome = "****************************" + Environment.NewLine +
                                                   "**   Library Management   **" + Environment.NewLine +
                                                   "****************************" + Environment.NewLine +
                                                   "Would you like to" + Environment.NewLine +
                                                   "  sort" + Environment.NewLine +
                                                   "  search" + Environment.NewLine +
                                                   "  add" + Environment.NewLine +
                                                   "  remove" + Environment.NewLine +
                                                   "  print" + Environment.NewLine +
                                                   "  end" + Environment.NewLine +
                                                   "****************************";
        public static string InvalidName = "Invalid Author name, must be between {0} and {1} symbols";
        public static string InvalidTitle = "Invalid Title, must be between {0} and {1} symbols";
        public static string InvalidISBN = "Invalid ISBN, must be exactly 13 digits";
        public static string InvalidBookLength = "Length must be positive!";
        public static string InvalidTypeOfBook = "Invalid type of book!";
        public static string InvalidGenreOfBook = "{0} is invalid book genre, possible types are {1}, {2} and {3}";
        public static string FunctionNotImplemented = "Function not implemented!";
        public static string BookAdded = "Book \"{0}\" was added!";
        public static string InvalidBookInput = "Invalid input!";
        public static string ChooseAlgorithm = "Choose algorithm:" + Environment.NewLine +
            " 1. Bubble sort / year published" + Environment.NewLine +
            " 2. Bubble sort / author name" + Environment.NewLine +
            " 3. Merge sort / year published" + Environment.NewLine +
            " 4. Merge sort / author name";
        public static string BooksSorted = "Sorting done! Time elapsed: {0}m {1}s {2}ms";
        public static string SearchDone = "Searching done!";
        public static string ChooseOrder = "asc / desc";
        public static string InputISBN = "Input 13-digit ISBN:";
        public static string BookRemoved = "Book removed!";
        public static string BookNotFound = "Book not found!";
        public static string InvalidOrderType = "Invalid order type!";

    }
}