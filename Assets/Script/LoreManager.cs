using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoreManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI loreText;
    public GameObject Message;

    [Header("Timing")]
    public float delayMin = 1f;
    public float delayMax = 3f;
    public float showDuration = 2.5f;

    [Range(0f, 1f)]
    public float appearChance = 0.35f;

    [Header("Messages")]
    public List<LoreMessage> mensagens;

    void Start()
    {
        loreText.text = "";
        Message.SetActive(false);

        Invoke(nameof(TryShowMessage), Random.Range(delayMin, delayMax));
    }

    void TryShowMessage()
    {
        if (Random.value > appearChance)
            return;

        LoreMessage msg = GetRandomMessage(mensagens);

        if (msg != null)
            StartCoroutine(Show(msg.text));
        Debug.Log("Tentando mostrar lore");
    }

    LoreMessage GetRandomMessage(List<LoreMessage> list)
    {
        if (list == null || list.Count == 0) return null;

        List<LoreMessage> valid = new List<LoreMessage>();

        foreach (var msg in list)
            if (Random.value <= msg.chance)
                valid.Add(msg);

        if (valid.Count == 0) return null;

        return valid[Random.Range(0, valid.Count)];
    }

    IEnumerator Show(string msg)
    {
        loreText.text = msg;
        Debug.Log("Lore exibido: " + msg);
        Message.SetActive(true);

        yield return new WaitForSeconds(showDuration);

        loreText.text = "";
        Message.SetActive(false);
    }
}