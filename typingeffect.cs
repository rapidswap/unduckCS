using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class typingeffect : MonoBehaviour
{
    public TMP_Text tx;
    string m_text = "������ ���� ���� ���� �ְ� �巳���� ��ġ�ϼ���!!";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    // Update is called once per frame

    IEnumerator _typing()
    {
        for(int i=0; i<=m_text.Length; i++)
        {
            tx.text= m_text.Substring(0,i);

            yield return new WaitForSeconds(0.15f);
        }
    }
}
