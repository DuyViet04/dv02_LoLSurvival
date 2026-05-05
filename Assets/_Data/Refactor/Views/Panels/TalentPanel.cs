using System.Collections.Generic;
using _Data.Refactor.Services.Talents;
using _Data.Refactor.Views.UIs;
using Base.Core.Architecture;
using Base.Systems.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Panels
{
    public class TalentPanel : BaseView
    {
        [SerializeField] private TMP_Text csPointsText;
        [SerializeField] private Transform talentListContent;
        [SerializeField] private TalentItemView talentItemPrefab;
        [SerializeField] private Button closeButton;

        private readonly List<TalentItemView> itemViews = new List<TalentItemView>();

        private void OnEnable()
        {
            TalentService.Ins.OnDataChanged += UpdateUI;
            closeButton.onClick.AddListener(ClosePanel);
            InitList();
            UpdateUI();
        }

        private void OnDisable()
        {
            TalentService.Ins.OnDataChanged -= UpdateUI;
            closeButton.onClick.RemoveListener(ClosePanel);
        }

        private void InitList()
        {
            itemViews.Clear();
            var existingViews = talentListContent.GetComponentsInChildren<TalentItemView>(true);
            var talents = TalentService.Ins.TalentGroup.talents;

            for (int i = 0; i < talents.Count; i++)
            {
                if (i < existingViews.Length)
                {
                    existingViews[i].SetTalent(talents[i]);
                    itemViews.Add(existingViews[i]);
                }
                else if (talentItemPrefab != null)
                {
                    var view = Instantiate(talentItemPrefab, talentListContent);
                    view.SetTalent(talents[i]);
                    itemViews.Add(view);
                }
            }
        }

        private void UpdateUI()
        {
            csPointsText.text = $"CS Points: {TalentService.Ins.CsPoints}";
            foreach (var view in itemViews)
            {
                view.UpdateUI();
            }
        }

        private void ClosePanel()
        {
            SoundManager.Ins.PlaySfx("Click");
            gameObject.SetActive(false);
        }
    }
}