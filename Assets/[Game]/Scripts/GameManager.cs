using System;
using _Game_.Scripts.Helpers;
using _Game_.Scripts.Input;
using UnityEngine;

/* ZTK was here
 * Namespace kullanımı genelde oyun içerisinde kullanılan ayrık sistemlerin iç işleyişini oyun kodlarından ayırmak için olur.
 * Ya da API yazılıyorsa aynı isimde class olabilme ihtimalini ortadan kaldırmak için yine bir namespace içinde yazılabilir.
 * Oyun kodlarını bu denli derinleşen namespace ler içine gizlemek Intellisense kullanımının amacını baltalar.
 * Projenin kod okunabilirliğini ağır oranda düşürür ve her yeni bir kod içine using yazmaya uğraştırır.
 */
namespace _Game_.Scripts
{
  public class GameManager : Singleton<GameManager>
  {
    private bool isInitialize = false;

    private void Awake()
    {
      if (isInitialize) return;
      InputManager.Instance.Initialize();
      Player.Player.Instance.Initialize();

      isInitialize = true;
    }
  }
}
