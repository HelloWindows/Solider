/*******************************************************************
 * FileName: CanvasTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace Framework {
    namespace Tools {
        public class CanvasTool {
            public static GameObject InstantiateEmptyUI(string name, RectTransform parent, Vector3 localPos) {
                return InstantiateEmptyUI(name, parent, localPos, Vector3.zero, Vector3.one);
            } // end InstantiateEmptyGo

            public static GameObject InstantiateEmptyUI(string name, RectTransform parent, Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                GameObject Go = ObjectTool.InstantiateEmptyGo(name, parent, localPos, localRot, localSca);
                Go.AddComponent<RectTransform>();
                return Go;
            } // end InstantiateEmptyGo

            public static Text InstantiateText(string name, RectTransform parent, Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                return InstantiateEmptyUI(name, parent, localPos, localRot, localSca).AddComponent<Text>();
            } // end InstantiateText

            public static Image InstantiateImage(string name, RectTransform parent, Vector3 localPos, Vector2 sizeDel) {
                Image image = InstantiateEmptyUI(name, parent, localPos, Vector3.zero, Vector3.one).AddComponent<Image>();
                image.raycastTarget = false;
                image.rectTransform.sizeDelta = sizeDel;
                return image;
            } // end InstantiateImage

            public static Image InstantiateImage(string name, RectTransform parent, Sprite sprite, Vector3 localPos, Vector2 sizeDel) {
                return InstantiateImage(name, parent, sprite, localPos, Vector3.zero, Vector3.one, sizeDel);
            } // end InstantiateImage

            public static Image InstantiateImage(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector3 localRot, Vector3 locaSca, Vector2 sizeDel) {
                Image image = InstantiateEmptyUI(name, parent, localPos, localRot, locaSca).AddComponent<Image>();
                image.sprite = sprite;
                image.raycastTarget = false;
                image.rectTransform.sizeDelta = sizeDel;
                return image;
            } // end InstantiateImage

            public static Image InstantiateImage(string name, RectTransform parent, string path, Vector3 localPos, Vector2 sizeDel) {
                return InstantiateImage(name, parent, path == null ? null : Resources.Load<Sprite>(path),
                    localPos, Vector3.zero, Vector3.one, sizeDel);
            } // end InstantiateImage

            public static Image InstantiateImage(string name, RectTransform parent, string path,
                Vector3 localPos, Vector3 localRot, Vector3 locaSca, Vector2 sizeDel) {
                return InstantiateImage(name, parent, path == null ? null : Resources.Load<Sprite>(path),
                    localPos, localRot, locaSca, sizeDel);
            } // end InstantiateImage

            public static Button InstantiateButton(string name, RectTransform parent, Vector3 localPos, Vector3 sizeDel, ColorBlock colors) {
                Image image = InstantiateImage(name, parent, localPos, sizeDel);
                image.raycastTarget = true;
                Button btn = image.gameObject.AddComponent<Button>();
                btn.transition = Selectable.Transition.ColorTint;
                btn.colors = colors;
                return btn;
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector3 localRot, Vector3 locaSca, Vector2 sizeDel, ColorBlock colors) {
                Image image = InstantiateImage(name, parent, sprite, localPos, localRot, locaSca, sizeDel);
                image.raycastTarget = true;
                Button btn = image.gameObject.AddComponent<Button>();
                btn.transition = Selectable.Transition.ColorTint;
                btn.colors = colors;
                return btn;
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector2 sizeDel, ColorBlock colors) {
                return InstantiateButton(name, parent, sprite, localPos, Vector3.zero, Vector3.one, sizeDel, colors);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, string path,
                Vector3 localPos, Vector2 sizeDel, ColorBlock colors) {
                return InstantiateButton(name, parent, path == "" ? null : Resources.Load<Sprite>(path),
                    localPos, sizeDel, colors);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, string path,
                Vector3 localPos, Vector3 localRot, Vector3 locaSca, Vector2 sizeDel, ColorBlock colors) {
                return InstantiateButton(name, parent, path == "" ? null : Resources.Load<Sprite>(path),
                    localPos, localRot, locaSca, sizeDel, colors);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Vector3 localPos, Vector2 sizeDel, SpriteState state) {
                Image image = InstantiateImage(name, parent, localPos, sizeDel);
                image.raycastTarget = true;
                Button btn = image.gameObject.AddComponent<Button>();
                btn.transition = Selectable.Transition.SpriteSwap;
                btn.spriteState = state;
                return btn;
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector3 localRot, Vector3 locaSca, Vector2 sizeDel, SpriteState state) {
                Image image = InstantiateImage(name, parent, sprite, localPos, localRot, locaSca, sizeDel);
                image.raycastTarget = true;
                Button btn = image.gameObject.AddComponent<Button>();
                btn.transition = Selectable.Transition.SpriteSwap;
                btn.spriteState = state;
                return btn;
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector2 sizeDel, SpriteState state) {
                return InstantiateButton(name, parent, sprite, localPos, Vector3.zero, Vector3.one, sizeDel, state);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, string path,
                Vector3 localPos, Vector2 sizeDel, SpriteState state) {
                return InstantiateButton(name, parent, path == "" ? null : Resources.Load<Sprite>(path),
                    localPos, sizeDel, state);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, string path,
                Vector3 localPos, Vector3 localRot, Vector3 locaSca, Vector2 sizeDel, SpriteState state) {
                return InstantiateButton(name, parent, path == "" ? null : Resources.Load<Sprite>(path),
                    localPos, localRot, locaSca, sizeDel, state);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector2 sizeDel, Vector2 touchDel, SpriteState state) {
                Image image = InstantiateImage(name, parent, sprite, localPos, sizeDel);
                Button btn = InstantiateImage("Btn", image.rectTransform, Vector3.zero, touchDel).gameObject.AddComponent<Button>();
                btn.targetGraphic.color = new Color(1, 1, 1, 0);
                btn.targetGraphic.raycastTarget = true;
                btn.targetGraphic = image;
                btn.transition = Selectable.Transition.SpriteSwap;
                btn.spriteState = state;
                return btn;
            } // end InstantialButton

            public static Button InstantiateButton(string name, RectTransform parent, string path,
                Vector3 localPos, Vector2 sizeDel, Vector2 touchDel, SpriteState state) {
                return InstantiateButton(name, parent, path == "" ? null : Resources.Load<Sprite>(path),
                    localPos, sizeDel, touchDel, state);
            } // end InstantiateButton

            public static Button InstantiateButton(string name, RectTransform parent, Sprite sprite,
                Vector3 localPos, Vector2 sizeDel, Vector2 touchDel, ColorBlock colors) {
                Image image = InstantiateImage(name, parent, sprite, localPos, sizeDel);
                Button btn = InstantiateImage("Btn", image.rectTransform, Vector3.zero, touchDel).gameObject.AddComponent<Button>();
                btn.targetGraphic.color = new Color(1, 1, 1, 0);
                btn.targetGraphic.raycastTarget = true;
                btn.targetGraphic = image;
                btn.transition = Selectable.Transition.ColorTint;
                btn.colors = colors;
                return btn;
            } // end InstantialButton

            public static Button InstantiateButton(string name, RectTransform parent, string path,
                Vector3 localPos, Vector2 sizeDel, Vector2 touchDel, ColorBlock colors) {
                return InstantiateButton(name, parent, path == "" ? null : Resources.Load<Sprite>(path),
                    localPos, sizeDel, touchDel, colors);
            } // end InstantiateButton
        } // end class CanvasTool
    } // end namespace Tools
} // end namespace Framework