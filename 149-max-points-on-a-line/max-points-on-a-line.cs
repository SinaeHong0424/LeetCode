public class Solution{
    public int MaxPoints(int[][] points){
        if(points.Length<=2)return points.Length;
        int maxPoints=1;
        for (int i=0; i<points.Length; i++){
            var slopes=new Dictionary<(int, int),int>();
            int duplicate=1;
            for (int j=i+1; j <points.Length; j++){
                int dx=points[j][0]-points[i][0];
                int dy=points[j][1]-points[i][1];
                if(dx==0 && dy==0){duplicate++;}
                else{int gcd=GCD(dx,dy); dx /=gcd; dy /=gcd;
                if(dy <0){dx=-dx; dy=-dy;}
                else if(dy==0){dx=Math.Abs(dx);}
                var slope=(dx,dy);
                if(slopes.ContainsKey(slope)){slopes[slope]++;}
                else{slopes[slope]=1;}
                }
            }int currentMax=duplicate;
            foreach(var count in slopes.Values){currentMax=Math.Max(currentMax,count+duplicate);}
            maxPoints=Math.Max(maxPoints,currentMax);
        }return maxPoints;
    }private int GCD(int a, int b){while (b !=0){int temp=b; b=a%b; a=temp;}
    return Math.Abs(a);}
}