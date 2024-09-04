public class Solution {
    public int MinMutation(string startGene, string endGene, string[] bank) {
        HashSet<string> geneBank = new HashSet<string>(bank);
        if (!geneBank.Contains(endGene)) {
            return -1; 
        }
        
        char[] geneChars = new char[] { 'A', 'C', 'G', 'T' };
                Queue<(string gene, int steps)> queue = new Queue<(string, int)>();
        HashSet<string> visited = new HashSet<string>(); 
        queue.Enqueue((startGene, 0));
        visited.Add(startGene);
        
        while (queue.Count > 0) {
            var (currentGene, steps) = queue.Dequeue();
                        for (int i = 0; i < currentGene.Length; i++) {
                foreach (char c in geneChars) {
                    if (c != currentGene[i]) { 
                        char[] mutatedGeneArr = currentGene.ToCharArray();
                        mutatedGeneArr[i] = c;
                        string mutatedGene = new string(mutatedGeneArr);
                        
                        if (mutatedGene == endGene) {
                            return steps + 1;
                        }
                        
                        if (geneBank.Contains(mutatedGene) && !visited.Contains(mutatedGene)) {
                            queue.Enqueue((mutatedGene, steps + 1));
                            visited.Add(mutatedGene); 
                        }
                    }
                }
            }
        }
                return -1;
    }
}
