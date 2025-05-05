using System;
using UnityEditor;
using UnityEngine;

namespace BzKovSoft.RagdollHelper.Editor {
	public class RagdollProperties {
		public bool asTrigger;
		public bool isKinematic;
		public bool useGravity = true;
		public bool createTips = true;
		public float rigidDrag;
		public float rigidAngularDrag;
		public CollisionDetectionMode cdMode;

		internal void Draw() {
			cdMode = (CollisionDetectionMode)EditorGUILayout.EnumPopup(new GUIContent("Collision detection:", "Il tipo di modalità di rilevamento delle collisioni da utilizzare per il Rigidbody."), cdMode);

			rigidDrag = EditorGUILayout.FloatField(new GUIContent("Rigid Drag:", "Resistenza lineare al movimento del Rigidbody. Maggiore è il valore, più velocemente l'oggetto rallenta fino a fermarsi."), rigidDrag);

			rigidAngularDrag = EditorGUILayout.FloatField(new GUIContent("Rigid Angular Drag:", "Resistenza alla rotazione del Rigidbody. Maggiore è il valore, più velocemente l'oggetto rallenta la sua rotazione fino a fermarsi."), rigidAngularDrag);

			asTrigger = EditorGUILayout.Toggle(new GUIContent("Trigger colliders:", "Se abilitato, i colliders agiranno come trigger e non bloccheranno fisicamente altri oggetti."), asTrigger);

			isKinematic = EditorGUILayout.Toggle(new GUIContent("Is kinematic:", "Se abilitato, il Rigidbody non sarà influenzato dalle forze fisiche e sarà controllato solo tramite script."), isKinematic);

			useGravity = EditorGUILayout.Toggle(new GUIContent("Use gravity:", "Determina se la gravità è abilitata per il Rigidbody. Se abilitato, l'oggetto sarà soggetto alla forza di gravità."), useGravity);

			createTips = EditorGUILayout.Toggle(new GUIContent("Create tips:", "Determina se creare colliders aggiuntivi per le estremità del ragdoll, come mani e piedi."), createTips);
		}
	}
}