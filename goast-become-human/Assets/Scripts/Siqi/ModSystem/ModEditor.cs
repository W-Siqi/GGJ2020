using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModEditor : MonoBehaviour
{
    public static ModEditor instance = null;

    public GameObject modWindow = null;
    public List<HeadImgSelector> headImgSelectors;
    public DefaultHeadImgSelector defaultHeadImgSelector;
    public int curPage = 0;

    private void Start()
    {
        ModArchive.ReadArchive().choosedHeadImagePath = ModArchive.DEFAUT_IMG_PATH;

        instance = this;

        RefreshModWindow();
    }

    public void OpenModWindow() {
        modWindow.SetActive(true);
        RefreshModWindow();
    }

    public void CloseModWindow() {
        modWindow.SetActive(false);
        RefreshModWindow();
    }

    public void OnDeleteHeadImage(string path) {
        var archive = ModArchive.ReadArchive();
        archive.headImagePaths.Remove(path);
        RefreshModWindow();
    }

    public void OnHeadImgSelected(string path) {
        ModArchive.ReadArchive().choosedHeadImagePath = path;
        RefreshModWindow();
    }

    public void HeadImgPageForward() {
        curPage++;
        RefreshModWindow();
    }

    public void HeadImgPageBackword()
    {
        curPage--;
        curPage = Mathf.Max(curPage, 0);
        RefreshModWindow();
    }

    public void RefreshModWindow() {
        InitHeadImageSelectors();
    }

    public void InitHeadImageSelectors() {
        var archive = ModArchive.ReadArchive();

        // defualt head img
        defaultHeadImgSelector.SetSelected(ModArchive.DEFAUT_IMG_PATH == archive.choosedHeadImagePath);

        // init page
        int countPerPage = headImgSelectors.Count;
        if (countPerPage == 0) {
            return;
        }

        int start = curPage * countPerPage;
        for (int i = 0; i < headImgSelectors.Count; i++) {
            // init images if it still reamins some
            if (i + start < archive.headImagePaths.Count)
            {
                var isSelected = archive.headImagePaths[i + start] == archive.choosedHeadImagePath;
                headImgSelectors[i].gameObject.SetActive(true);
                headImgSelectors[i].InitSelector(archive.headImagePaths[i + start],isSelected);
            }
            else {
                headImgSelectors[i].gameObject.SetActive(false);
            }
        }
    }
}
