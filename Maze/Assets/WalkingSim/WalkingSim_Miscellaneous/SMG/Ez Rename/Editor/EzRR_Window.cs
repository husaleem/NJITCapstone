﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace SMG.EzRenamer
{
	public class EzRR_Window : EditorWindow
    {
	    private Vector2 scrollPos;
        
	    private static Texture2D ezRenameIcon;

	    private EzRR_Rename rename;
	    private EzRR_Replace replace;
	    private EzRR_Insert insert;
	    private EzRR_Remove remove;
	    private EzRR_CaseChange caseChange;
	    private EzRR_Sort sort;
	    

	    private void OnEnable()
	    {
		    rename = ScriptableObject.CreateInstance<EzRR_Rename>();
		    replace = ScriptableObject.CreateInstance<EzRR_Replace>();
		    insert = ScriptableObject.CreateInstance<EzRR_Insert>();
		    remove = ScriptableObject.CreateInstance<EzRR_Remove>();
		    caseChange = ScriptableObject.CreateInstance<EzRR_CaseChange>();
		    sort = ScriptableObject.CreateInstance<EzRR_Sort>();
	    }

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
	        EditorGUILayout.Space();
	        rename.Draw();
	        EzRR_Style.DrawUILine(EzRR_Style.uiLineColor);
	        replace.Draw();
	        EzRR_Style.DrawUILine(EzRR_Style.uiLineColor);
	        insert.Draw();
	        EzRR_Style.DrawUILine(EzRR_Style.uiLineColor);
	        remove.Draw();
	        EzRR_Style.DrawUILine(EzRR_Style.uiLineColor);
	        caseChange.Draw();
	        EzRR_Style.DrawUILine(EzRR_Style.uiLineColor);
	        sort.Draw();
            EzRR_Style.DrawUILine(EzRR_Style.uiLineColor);
	        EzRR_Style.DrawFooter();
            EditorGUILayout.EndScrollView();
        }
        #region ========== Menu Items ==========================================
        [MenuItem("Window/Ez Rename")]
	    private static void OpenWindow()
        {
	        GUIContent _titleContent = new GUIContent("Ez Rename");
	        ezRenameIcon = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/SMG/Ez Rename/Editor/Editor Resources/Icons/ez-rename-icon.png", typeof(Texture2D));
	        _titleContent.image = ezRenameIcon;   
	        EditorWindow _window = EditorWindow.GetWindow(typeof(EzRR_Window));
	        _window.minSize = new Vector2(300, 415);	   
            _window.autoRepaintOnSceneChange = true;
            _window.titleContent = _titleContent;
            _window.Show();
        }

        // Open Window
        [MenuItem("GameObject/Ez Rename/Open Window", false, 48)]
        private static void MenuOpenWindow() { OpenWindow(); }
        // Sort Selection
        [MenuItem("GameObject/Ez Rename/Sort Selection/Name A_Z", false, 49)]
	    private static void MenuSortSelectNameA_Z()  { EzRR_Sort.ShortcutSortConfig(EzRR_Sort.SortOptions.nameA_Z, false); }
        [MenuItem("GameObject/Ez Rename/Sort Selection/Name Z_A", false, 50)]
	    private static void MenuSortSelectNameZ_A()  { EzRR_Sort.ShortcutSortConfig(EzRR_Sort.SortOptions.nameZ_A, false); }

        // Sort Children
        [MenuItem("GameObject/Ez Rename/Sort Children/Name A_Z", false, 49)]
	    private static void MenuSortChildNameA_Z() { EzRR_Sort.ShortcutSortConfig(EzRR_Sort.SortOptions.nameA_Z, true); }
        [MenuItem("GameObject/Ez Rename/Sort Children/Name Z_A", false, 50)]
	    private static void MenuSortChildNameZ_A() { EzRR_Sort.ShortcutSortConfig(EzRR_Sort.SortOptions.nameZ_A, true); }
        #endregion ======= Menu Items ==========================================
    }
}