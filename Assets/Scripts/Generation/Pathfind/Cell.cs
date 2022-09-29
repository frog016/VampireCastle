using UnityEngine;

namespace Assets.Scripts.Pathfind
{
    public struct Cell
    {
        public readonly Vector2 Position;
        public readonly CellAttendance Attendance;

        public Cell(Vector2 position, CellAttendance attendance)
        {
            Position = position;
            Attendance = attendance;
        }
    }
}