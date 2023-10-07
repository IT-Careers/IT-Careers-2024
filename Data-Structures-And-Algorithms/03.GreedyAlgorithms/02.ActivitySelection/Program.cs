class Program
{
    static List<int> activityStarts = new List<int> { 3, 1, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
    static List<int> activityEnds = new List<int> { 5, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
    static List<int> selectedActivitiesIndexes = new List<int>();
    static List<int> validActivityIndexes = new List<int>();

    static void Main(string[] args)
    {
        for (int i = 0; i < activityStarts.Count; i++)
        {
            validActivityIndexes.Add(i);
        }

        while (validActivityIndexes.Count > 0)
        {
            SelectActivity();
            RemoveInvalidActivities();
        }

        Console.WriteLine(string.Join(" ", selectedActivitiesIndexes.Select(x => $"{activityStarts[x]} - {activityEnds[x]}")));
    }

    private static void RemoveInvalidActivities()
    {
        int lastSelectedActivityIndex = selectedActivitiesIndexes.Last();
        int lastSelectedActivityEndTime = activityEnds[lastSelectedActivityIndex];

        for (int i = 0; i < activityStarts.Count; i++)
        {
            int activityStartTime = activityStarts[i];

            if (activityStartTime < lastSelectedActivityEndTime)
            {
                validActivityIndexes.Remove(i);
            }
        }
    }

    private static void SelectActivity()
    {
        int earliestActivityEndTime = int.MaxValue;
        int selectedIndex = -1;

        for (int i = 0; i < activityEnds.Count; i++)
        {
            int currentEndTime = activityEnds[i];

            if (earliestActivityEndTime > currentEndTime && validActivityIndexes.Contains(i))
            {
                earliestActivityEndTime = currentEndTime;
                selectedIndex = i;
            }
        }

        selectedActivitiesIndexes.Add(selectedIndex);
        validActivityIndexes.Remove(selectedIndex);
    }
}