using UnityEngine;

namespace GreenLeaf
{
    public static class AdvancedPlayerPrefs
    {
        #region Bool

        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            PlayerPrefs.SetString(key + "type", "bool");
        }

        public static bool GetBool(string key, bool defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        #endregion

        #region String

        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.SetString(key + "type", "string");
        }

        public static string GetString(string key, string defaultValue)
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        #endregion

        #region Color

        public static void SetColor(string key, Color value)
        {
            string colorString = ColorUtility.ToHtmlStringRGBA(value);

            PlayerPrefs.SetString(key, colorString);
        }

        public static Color GetColor(string key, Color defaultValue)
        {
            string colorString = PlayerPrefs.GetString(key, ColorUtility.ToHtmlStringRGBA(defaultValue));

            if (ColorUtility.TryParseHtmlString("#" + colorString, out Color color))
            {
                return color;
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion

        #region Int

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.SetString(key + "type", "int");
        }

        public static int GetInt(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        #endregion

        #region Float

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.SetString(key + "type", "float");
        }

        public static float GetFloat(string key, float defaultValue)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        #endregion

        #region Vector2

        public static void SetVector2(string key, Vector2 value)
        {
            PlayerPrefs.SetFloat(key + "x", value.x);
            PlayerPrefs.SetFloat(key + "y", value.y);
            PlayerPrefs.SetString(key + "type", "vector2");
        }

        public static Vector2 GetVector2(string key, Vector2 defaultValue)
        {
            Vector2 vector = new Vector2();

            vector.x = PlayerPrefs.GetFloat(key + "x", defaultValue.x);
            vector.y = PlayerPrefs.GetFloat(key + "y", defaultValue.y);

            return vector;
        }

        #endregion

        #region Vector3

        public static void SetVector3(string key, Vector3 value)
        {
            PlayerPrefs.SetFloat(key + "x", value.x);
            PlayerPrefs.SetFloat(key + "y", value.y);
            PlayerPrefs.SetFloat(key + "z", value.z);
            PlayerPrefs.SetString(key + "type", "vector3");
        }

        public static Vector3 GetVector3(string key, Vector3 defaultValue)
        {
            Vector3 vector = new Vector3();

            vector.x = PlayerPrefs.GetFloat(key + "x", defaultValue.x);
            vector.y = PlayerPrefs.GetFloat(key + "y", defaultValue.y);
            vector.z = PlayerPrefs.GetFloat(key + "z", defaultValue.z);

            return vector;
        }

        #endregion

        #region Vector4

        public static void SetVector4(string key, Vector4 value)
        {
            PlayerPrefs.SetFloat(key + "x", value.x);
            PlayerPrefs.SetFloat(key + "y", value.y);
            PlayerPrefs.SetFloat(key + "z", value.z);
            PlayerPrefs.SetFloat(key + "w", value.w);
            PlayerPrefs.SetString(key + "type", "vector4");
        }

        public static Vector4 GetVector4(string key, Vector4 defaultValue)
        {
            Vector4 vector = new Vector4();

            vector.x = PlayerPrefs.GetFloat(key + "x", defaultValue.x);
            vector.y = PlayerPrefs.GetFloat(key + "y", defaultValue.y);
            vector.z = PlayerPrefs.GetFloat(key + "z", defaultValue.z);
            vector.w = PlayerPrefs.GetFloat(key + "w", defaultValue.w);

            return vector;
        }

        #endregion

        #region Quaternion

        public static void SetQuaternion(string key, Quaternion value)
        {
            PlayerPrefs.SetFloat(key + "x", value.x);
            PlayerPrefs.SetFloat(key + "y", value.y);
            PlayerPrefs.SetFloat(key + "z", value.z);
            PlayerPrefs.SetFloat(key + "w", value.w);
            PlayerPrefs.SetString(key + "type", "quaternion");
        }

        public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
        {
            Quaternion quaternion = new Quaternion();

            quaternion.x = PlayerPrefs.GetFloat(key + "x", defaultValue.x);
            quaternion.y = PlayerPrefs.GetFloat(key + "y", defaultValue.y);
            quaternion.z = PlayerPrefs.GetFloat(key + "z", defaultValue.z);
            quaternion.w = PlayerPrefs.GetFloat(key + "w", defaultValue.w);

            return quaternion;
        }

        #endregion

        #region Transform

        public static void SetTransform(string key, Transform value)
        {
            PlayerPrefs.SetFloat(key + "XPosition", value.position.x);
            PlayerPrefs.SetFloat(key + "YPosition", value.position.y);
            PlayerPrefs.SetFloat(key + "ZPosition", value.position.z);

            PlayerPrefs.SetFloat(key + "XRotation", value.rotation.x);
            PlayerPrefs.SetFloat(key + "YRotation", value.rotation.y);
            PlayerPrefs.SetFloat(key + "ZRotation", value.rotation.z);
            PlayerPrefs.SetFloat(key + "WRotation", value.rotation.w);

            PlayerPrefs.SetFloat(key + "XScale", value.localScale.x);
            PlayerPrefs.SetFloat(key + "YScale", value.localScale.y);
            PlayerPrefs.SetFloat(key + "ZScale", value.localScale.z);

            PlayerPrefs.SetString(key + "type", "transform");
        }

        public static Transform GetTransform(string key, Transform defaultValue)
        {
            GameObject gameObject = new GameObject();

            Transform transform = gameObject.transform;

            Vector3 Position = Vector3.zero;
            Quaternion Rotation = Quaternion.identity;
            Vector3 Scale = Vector3.zero;

            Position.x = PlayerPrefs.GetFloat(key + "XPosition", defaultValue.position.x);
            Position.y = PlayerPrefs.GetFloat(key + "YPosition", defaultValue.position.y);
            Position.z = PlayerPrefs.GetFloat(key + "ZPosition", defaultValue.position.z);

            Rotation.x = PlayerPrefs.GetFloat(key + "XRotation", defaultValue.rotation.x);
            Rotation.y = PlayerPrefs.GetFloat(key + "YRotation", defaultValue.rotation.y);
            Rotation.z = PlayerPrefs.GetFloat(key + "ZRotation", defaultValue.rotation.z);
            Rotation.w = PlayerPrefs.GetFloat(key + "WRotation", defaultValue.rotation.w);

            Scale.x = PlayerPrefs.GetFloat(key + "XScale", defaultValue.localScale.x);
            Scale.y = PlayerPrefs.GetFloat(key + "YScale", defaultValue.localScale.y);
            Scale.z = PlayerPrefs.GetFloat(key + "ZScale", defaultValue.localScale.z);

            transform.position = Position;
            transform.rotation = Rotation;
            transform.localScale = Scale;

            return transform;
        }

        #endregion

        #region OtherOptions

        public static void DeleteKey(string key)
        {
            if (PlayerPrefs.GetString(key + "type") == "bool" || PlayerPrefs.GetString(key + "type") == "string" || PlayerPrefs.GetString(key + "type") == "int" || PlayerPrefs.GetString(key + "type") == "float" || PlayerPrefs.GetString(key + "type") == "color")
            {
                PlayerPrefs.DeleteKey(key);
                PlayerPrefs.DeleteKey(key + "type");
            }
            else if (PlayerPrefs.GetString(key) == "vector2")
            {
                PlayerPrefs.DeleteKey(key + "x");
                PlayerPrefs.DeleteKey(key + "y");

                PlayerPrefs.DeleteKey(key + "type");
            }
            else if (PlayerPrefs.GetString(key) == "vector3")
            {
                PlayerPrefs.DeleteKey(key + "x");
                PlayerPrefs.DeleteKey(key + "y");
                PlayerPrefs.DeleteKey(key + "z");

                PlayerPrefs.DeleteKey(key + "type");
            }
            else if (PlayerPrefs.GetString(key) == "vector4" || PlayerPrefs.GetString(key) == "quaternion")
            {
                PlayerPrefs.DeleteKey(key + "x");
                PlayerPrefs.DeleteKey(key + "y");
                PlayerPrefs.DeleteKey(key + "z");
                PlayerPrefs.DeleteKey(key + "w");

                PlayerPrefs.DeleteKey(key + "type");
            }
            else if (PlayerPrefs.GetString(key) == "transform")
            {
                PlayerPrefs.DeleteKey(key + "XPosition");
                PlayerPrefs.DeleteKey(key + "YPosition");
                PlayerPrefs.DeleteKey(key + "ZPosition");

                PlayerPrefs.DeleteKey(key + "XRotation");
                PlayerPrefs.DeleteKey(key + "YRotation");
                PlayerPrefs.DeleteKey(key + "ZRotation");
                PlayerPrefs.DeleteKey(key + "WRotation");

                PlayerPrefs.DeleteKey(key + "XScale");
                PlayerPrefs.DeleteKey(key + "YScale");
                PlayerPrefs.DeleteKey(key + "ZScale");

                PlayerPrefs.DeleteKey(key + "type");
            }
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public static bool HasKey(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                return true;
            }
            else if (PlayerPrefs.HasKey(key + "x"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Save()
        {
            PlayerPrefs.Save();
        }

        #endregion
    }
}
