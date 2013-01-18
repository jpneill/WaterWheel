(* ::Package:: *)

BeginPackage["ChaosWheel2`"]
(* Public exposure of the symbol DESolve and others if required *)
ChaosWheel2::usage = "ChaosWheel2[Radius, Prandtl Number, Rayleigh Number, Leakage Rate, Inflow Rate, Critical Angle, Number of Buckets, Simulation Time, Initial Velocity] Solves the chaotic waterwheel for the input values and outputs an array of angles and mass of buckets for 50ms timesteps."
(* Private implementation area *)
Begin["`Private`"]
ChaosWheel2[radius_,Prandtl_,Rayleigh_,leakage_,Inflow_,Qc_,numbuckets_,timescale_,InitVel_]:=Module[{r,\[Sigma],\[Rho],k,q,c,n,time,q1,v,inertia,zero,abs,eq34,eqss,init,eq,y0,solution,Angles,Masses,Res,w,\[Theta]},
r=radius;
\[Sigma]=Prandtl;
\[Rho]=Rayleigh;
k=leakage;
q=Inflow;
c=(Qc \[Pi])/180;
n=numbuckets;
time=timescale;
q1=(2 q Sin[c])/\[Pi];
v=(9.81 \[Pi] r q1)/(k^2 \[Rho]);
inertia = v/(\[Sigma] k);
zero={a[0]'[t]==-k a[0][t],b[0]'[t]==-k b[0][t]+(2 q c)/\[Pi]};
abs=Join[zero,Table[a[i]'[t]==i w[t] b[i][t] - k a[i][t],{i,1,5}],
Table[b[i]'[t]==- i w[t] a[i][t]-k b[i][t]+(2 q Sin[i c])/(i \[Pi]),{i,1,5}]];
eq34={w'[t]==-v/inertia w[t]+(\[Pi] 9.81 r)/inertia a[1][t],\[Theta]'[t]==w[t]};
eqss=Join[abs,eq34];
init =Flatten[{ Flatten[Table[{a[i][0]==0,b[i][0]==0},{i,0,5}]],w[0]==InitVel,\[Theta][0]==0}];
eq=Join[eqss,init];
y0=Flatten[{Flatten[Table[{a[i][t],b[i][t]},{i,0,5}]],w[t],\[Theta][t]}];
solution=NDSolve[eq,y0,{t,0,time},MaxSteps ->100000];
Subscript[a, 0][t_]=solution[[1,1,2,0]][t];
Subscript[a, 1][t_]=solution[[1,3,2,0]][t];
Subscript[a, 2][t_]=solution[[1,5,2,0]][t];
Subscript[a, 3][t_]=solution[[1,7,2,0]][t];
Subscript[a, 4][t_]=solution[[1,9,2,0]][t];
Subscript[a, 5][t_]=solution[[1,11,2,0]][t];
Subscript[b, 0][t_]=solution[[1,2,2,0]][t];
Subscript[b, 1][t_]=solution[[1,4,2,0]][t];
Subscript[b, 2][t_]=solution[[1,6,2,0]][t];
Subscript[b, 3][t_]=solution[[1,8,2,0]][t];
Subscript[b, 4][t_]=solution[[1,10,2,0]][t];
Subscript[b, 5][t_]=solution[[1,12,2,0]][t];
w[t_]=solution[[1,13,2,0]][t];
\[Theta][t_]=solution[[1,14,2,0]][t];
m[angle_,t_]:=\!\(
\*UnderoverscriptBox[\(\[Sum]\), \(n = 0\), \(4\)]\((
\(\*SubscriptBox[\(a\), \(n\)]\)[t] Sin[n\ angle] + 
\(\*SubscriptBox[\(b\), \(n\)]\)[t] Cos[n\ angle])\)\);
M[t_,th1_,th2_]:=NIntegrate[m[theta,t],{theta,th1,th2}];
Angles=Table[{\[Theta][t]},{t,1/20,time,1/20}];
Masses=Table[Flatten[Table[M[t,(x 2 \[Pi])/n,((x+1)2\[Pi])/n],{x,0,n-1}]],{t,1/20,time,1/20}];
Res=Table[Join[Angles[[x]],Masses[[x]]],{x,Length[Angles]}]
]
(* One or more functions defined here *)
End[]
EndPackage[]



