public class Solution {
    public int MinFlips(int a, int b, int c) {
        int flips = 0;
        
        for (int i = 0; i < 32; i++) {
            bool bitA = ((a >> i) & 1) == 1;
            bool bitB = ((b >> i) & 1) == 1;
            bool bitC = ((c >> i) & 1) == 1;
            
            if ((bitA | bitB) != bitC) {
                if (bitC) {
                    if (!bitA && !bitB) {
                        flips += 1;
                    }
                } else {
                    if (bitA) {
                        flips += 1;
                    }
                    if (bitB) {
                        flips += 1;
                    }
                }
            }
        }
        
        return flips;
    }
}
