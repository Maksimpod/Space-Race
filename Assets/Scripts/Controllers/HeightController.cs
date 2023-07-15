using System.Collections;
using UnityEngine;

namespace RS2023.Scripts.Controllers
{
    public class HeightController
    {
        private HeightModel _heightModel;

        public HeightController(HeightModel heightModel)
        {
            _heightModel = heightModel;
        }

        public void InitializeUpgradeButton()
        {
            _heightModel.EngineUpgradeButton.onClick.AddListener(UpgradeEngine);
            _heightModel.GetShopMenu.UpdateEngineText(_heightModel.engineMultiplier);
        }

        public void BoostOnStart(int multi)
        {
            _heightModel.StartCoroutine(ScoreBooster(multi));
            _heightModel.GetHUD.DisableBoostRoulette();
        }

        public IEnumerator Score()
        {
            yield return new WaitForSeconds(0.01f);
            while (true)
            {
                _heightModel.Height += _heightModel.engineMultiplier;
                yield return new WaitForSeconds(0.1f);
            }
        }

        public IEnumerator CheckHeightFlags()
        {
            while (_heightModel.triggerIndex < 4)
            {
                if (_heightModel.Height > _heightModel.heightFlags[_heightModel.triggerIndex])
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
            while (_heightModel.Height <= _heightModel.RokValue * multiplier * _heightModel.engineMultiplier)
            {
                _heightModel.Height += 1;
                yield return new WaitForSeconds(0.035f / (multiplier * _heightModel.engineMultiplier));
            }
        }

        public void UpdateTotalScore()
        {
            _heightModel.GetHUD.SetTotalScoreText(_heightModel.Height / _heightModel.RokValue, _heightModel.recordHeight / _heightModel.RokValue);
            _heightModel.recordHeight = _heightModel.Height > _heightModel.recordHeight ? _heightModel.Height : _heightModel.recordHeight;
        }

        public void UpgradeEngine()
        {
            if (_heightModel.GetCoinModel.Coins >= _heightModel.engineMultiplier)
            {
                _heightModel.GetCoinModel.Coins -= _heightModel.engineMultiplier;
                _heightModel.engineMultiplier += 1;
                _heightModel.GetShopMenu.UpdateEngineText(_heightModel.engineMultiplier);
            }
        }
    }

}