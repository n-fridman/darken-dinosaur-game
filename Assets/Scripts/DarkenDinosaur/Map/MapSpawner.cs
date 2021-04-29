using System;
using System.Collections.Generic;
using System.Linq;
using DarkenDinosaur.ResourcesManagementSystem;
using UnityEngine;

namespace DarkenDinosaur.Map
{
    [RequireComponent(typeof(TemplatesLoader))]
    public class MapSpawner : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TemplatesLoader templatesLoader;
        
        [Header("Settings")] 
        [Tooltip("Map parent transform.")]
        [SerializeField] private Transform templatesParentTransform;
        
        [Tooltip("Templates count on scene in one moment.")]
        [SerializeField] private int templatesPoolSize;

        [Tooltip("Template size.")]
        [SerializeField] private Vector3 templateSize;

        [Tooltip("Templates on scene.")]
        [SerializeField] private List<GameObject> spawnedTemplates;
        
        private void Awake()
        {
            if (this.templatesLoader == null) this.templatesLoader = GetComponent<TemplatesLoader>();
        }

        private void Update()
        {
            if (this.spawnedTemplates.Count < this.templatesPoolSize)
            {
                SpawnTemplate();
            }
        }

        /// <summary>
        /// Spawn new template on scene.
        /// </summary>
        private void SpawnTemplate()
        {
            GameObject template = this.templatesLoader.GetRandomTemplate();
            GameObject spawnedTemplate = Instantiate(template, this.templatesParentTransform);
            
            GameObject lastSpawnedTemplate = this.spawnedTemplates.Last();
            Vector3 lastSpawnedTemplatePosition = lastSpawnedTemplate.transform.localPosition;
            Vector3 templatePosition = lastSpawnedTemplatePosition + this.templateSize;

            spawnedTemplate.transform.localPosition = templatePosition;
            this.spawnedTemplates.Add(spawnedTemplate);
        }
        
        /// <summary>
        /// Destroy template from scene.
        /// </summary>
        /// <param name="template">Template to destroying.</param>
        public void DeleteTemplate(GameObject template)
        {
            this.spawnedTemplates.Remove(template);
            Destroy(template);
        }
    }
}