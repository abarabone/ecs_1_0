using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public abstract class MeshModelBase : MonoBehaviour
{

    // character model の
    // ボーンは、skinned mesh component から取得する？
    // インスタンスではヒエラルキーから構築する
    // ただし draw 時は、ボーン構成が一致しないといけない

    // model group は直接辞書を持つ
    // 単体インスタンスは、

    // model group の子にモデルを置くようにする？（配列で登録ではなくて）
    // プレハブのほうがいいか、余計なレンダラのコンバートとか入らないだろうし
}
