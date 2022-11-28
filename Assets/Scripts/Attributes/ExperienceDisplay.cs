using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experience;
        void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        void Update()
        {
            GetComponent<Text>().text = String.Format("{0:0}", experience.GetPoints());
        }
    }
}
