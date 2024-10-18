public class Solution {
    private static readonly byte[] ReverseByte=new byte[256];
    static Solution(){
        for (int i=0; i<256; i++){ReverseByte[i]=ReverseBitsInByte((byte)i);}
    }
    private static byte ReverseBitsInByte(byte b){
        byte result=0;
        for (int i=0; i<8; i++){result |=(byte)(((b>>i)&1)<<(7-i));}return result;
    }
    public uint reverseBits(uint n){
        return (uint)(ReverseByte[n &0xFF] <<24 |
        ReverseByte[(n >> 8)&0xFF]<<16 |
        ReverseByte[(n >> 16) & 0xFF] <<8 |
        ReverseByte[(n >> 24)&0xFF]);
    }
}