/// <summary>
/// �֗��N���X
/// </summary>
public static class Utility
{
    public static readonly string Player1CustomPropertyKey = "Player1";
    public static readonly string Player2CustomPropertyKey = "Player2";

    /// <summary>
    /// �v���C���[�ԍ��ŃJ�X�^���v���p�e�B�̃L�[���擾�������ꍇ�͂��̃��\�b�h���Ăяo������
    /// </summary>
    public static string GetPlayerCustomPropertyKey(int playerNum)
    {
        if (playerNum == 1)
        {
            return Player1CustomPropertyKey;
        }
        else if (playerNum == 2)
        {
            return Player2CustomPropertyKey; ;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("�����̓v���C���[�̔ԍ��Ȃ̂�1��������2");
        }
    }
}
