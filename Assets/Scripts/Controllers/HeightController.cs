using System.Collections;
using UnityEngine;

public class HeightController
{
    private HeightModel _heightModel;

    public HeightController(HeightModel heightModel)
    {
        _heightModel = heightModel;
    }

    public void BoostOnStart()
    {
        _heightModel.StartCoroutine(ScoreBooster(_heightModel.multiplier));
        _heightModel.GetHUD.DisableBoostButtons();
    }

    public IEnumerator Score()
    {
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            _heightModel.height += 1;
            _heightModel.GetHUD.SetHeightText(_heightModel.height);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator CheckHeightFlags()
    {
        while (_heightModel.triggerIndex < 4)
        {
            if (_heightModel.height > _heightModel.heightFlags[_heightModel.triggerIndex])
            {
                _heightModel.GetBackgroundController.ChangeBackground(_heightModel.triggerIndex);
                _heightModel.triggerIndex += 1;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator ScoreBooster(int multiplier)
    {
        yield return new WaitForSeconds(0.01f);
        while (_heightModel.height <= 50 * multiplier)
        {
            _heightModel.height += 1;
            _heightModel.GetHUD.SetHeightText(_heightModel.height);
            yield return new WaitForSeconds(0.035f / multiplier);
        }
    }

    public void UpdateTotalScore()
    {
        _heightModel.recordHeight = _heightModel.height;
        _heightModel.GetHUD.SetTotalScoreText(_heightModel.height, _heightModel.recordHeight);
    }
}
