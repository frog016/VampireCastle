using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardRecordUI : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private RawImage _image;

    public void InitializeRecord(LeaderBoardRecord dataRecord)
    {
        _nameText.text = dataRecord.Name;
        _scoreText.text = dataRecord.Score.ToString();
        _image.texture = dataRecord.ImageTexture;
    }

    public struct LeaderBoardRecord
    {
        public readonly string Name;
        public readonly int Score;
        public readonly Texture ImageTexture;

        public LeaderBoardRecord(string name, int score, Texture imageTexture)
        {
            Name = name;
            Score = score;
            ImageTexture = imageTexture;
        }
    }
}
