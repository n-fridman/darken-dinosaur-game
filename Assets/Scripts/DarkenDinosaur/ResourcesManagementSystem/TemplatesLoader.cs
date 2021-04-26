using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DarkenDinosaur.ResourcesManagementSystem
{
    public class TemplatesLoader : MonoBehaviour
    {
        [Header("Settings")] 
        [Tooltip("Loaded templates.")]
        [SerializeField] private List<GameObject> loadedTemplates;
        
        [Tooltip("Templates folder name in resources.")]
        [SerializeField] private string templatesFolderName;

        [Tooltip("Template name prefix.")]
        [SerializeField] private string templatePrefix;
        
        [Tooltip("Templates count in resources folder.")]
        [SerializeField] private int templatesCount;

        /// <summary>
        /// Return random template from loaded pool or resources folder.
        /// </summary>
        /// <returns>Location template (GameObject)</returns>
        public GameObject GetRandomTemplate()
        {
            int templateId = Random.Range(1, this.templatesCount);
            string templateName = this.templatePrefix + templateId;
            if (this.loadedTemplates.Exists(t => t.name == templateName))
            {
                Debug.Log("{<color=cyan><b>Template Loaded Log</b></color>} => [TemplatesLoader] - (<color=yellow>GetRandomTemplate</color>) -> Template " + templateName + " return from loaded templates.");
                GameObject template = this.loadedTemplates.Find(t => t.name == templateName);
                return template;
            }

            string templateResourcePath = Path.Combine(this.templatesFolderName, templateName);
            GameObject loadedTemplate = Resources.Load<GameObject>(templateResourcePath);
            this.loadedTemplates.Add(loadedTemplate);
            Debug.Log("{<color=cyan><b>Template Loaded Log</b></color>} => [TemplatesLoader] - (<color=yellow>GetRandomTemplate</color>) -> Template " + templateName + " loaded from resources.");
            return loadedTemplate;
        }
    }
}
