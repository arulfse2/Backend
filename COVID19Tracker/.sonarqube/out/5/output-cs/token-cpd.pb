µH
SC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\Config.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

static 
class 
Config 
{ 
public		 
static		 
IEnumerable		 !
<		! "
IdentityResource		" 2
>		2 3 
GetIdentityResources		4 H
=>		I K
new

	 
List

 
<

 
IdentityResource

 "
>

" #
{	 

new 
IdentityResources %
.% &
OpenId& ,
(, -
)- .
,. /
new 
IdentityResources %
.% &
Profile& -
(- .
). /
,/ 0
new 
IdentityResources %
.% &
Email& +
(+ ,
), -
,- .
new 
IdentityResource $
($ %
$str 
, 
$str "
," #
new 
List 
< 
string #
># $
($ %
)% &
{' (
$str) /
}0 1
)1 2
}	 

;
 
public 
static 
IEnumerable !
<! "
ApiResource" -
>- .
GetApiResources/ >
=>? A
new	 
List 
< 
ApiResource 
> 
{ 
new 
ApiResource 
(  
$str  )
,) *
$str* 4
,4 5
new5 8
List9 =
<= >
string> D
>D E
{F G
$strH N
,N O
$strP W
,W X
$strY _
}_ `
)` a
{ 

ApiSecrets 
=  
{ 
new 
Secret "
(" #
$str# 2
.2 3
Sha2563 9
(9 :
): ;
); <
} 
, 
Scopes 
= 
{ 
$str &
}   
}!! 
,!! 
new"" 
ApiResource"" 
(""  
$str""  /
,""/ 0
$str""0 @
,""@ A
new""A D
List""E I
<""I J
string""J P
>""P Q
{""R S
$str""T Z
,""Z [
$str""\ c
,""c d
$str""e k
}""k l
)""l m
{## 

ApiSecrets$$ 
=$$  
{%% 
new&& 
Secret&& "
(&&" #
$str&&# 8
.&&8 9
Sha256&&9 ?
(&&? @
)&&@ A
)&&A B
}'' 
,'' 
Scopes(( 
=(( 
{)) 
$str** ,
}++ 
},, 
,,, 
new-- 
ApiResource-- 
(--  
$str--  1
,--1 2
$str--2 D
,--D E
new--E H
List--I M
<--M N
string--N T
>--T U
{--V W
$str--X ^
,--^ _
$str--` g
,--g h
$str--i o
}--o p
)--p q
{.. 

ApiSecrets// 
=//  
{00 
new11 
Secret11 "
(11" #
$str11# :
.11: ;
Sha25611; A
(11A B
)11B C
)11C D
}22 
,22 
Scopes33 
=33 
{44 
$str55 .
}66 
}77 
,77 
new88 
ApiResource88 
(88  
$str88  *
,88* +
$str88+ 6
,886 7
new887 :
List88; ?
<88? @
string88@ F
>88F G
{88H I
$str88J P
,88P Q
$str88R Y
}88Z [
)88[ \
{99 

ApiSecrets:: 
=::  
{;; 
new<< 
Secret<< "
(<<" #
$str<<# 3
.<<3 4
Sha256<<4 :
(<<: ;
)<<; <
)<<< =
}== 
,== 
Scopes>> 
=>> 
{?? 
$str@@ '
}AA 
}BB 
}CC 
;CC 
publicDD 
staticDD 
IEnumerableDD !
<DD! "
ApiScopeDD" *
>DD* +
GetApiScopesDD, 8
=>DD9 ;
newEE	 
ListEE 
<EE 
ApiScopeEE 
>EE 
{FF 
newGG 
ApiScopeGG 
{HH 
NameII 
=II 
$strII )
,II) *
DisplayNameJJ 
=JJ  !
$strJJ" B
,JJB C

UserClaimsKK 
=KK  
{KK! "
$strKK# )
,KK) *
$strKK+ 2
,KK2 3
$strKK4 :
}KK; <
}LL 
,LL 
newMM 
ApiScopeMM 
{NN 
NameOO 
=OO 
$strOO /
,OO/ 0
DisplayNamePP 
=PP  !
$strPP" H
,PPH I

UserClaimsQQ 
=QQ  
{QQ! "
$strQQ# )
,QQ) *
$strQQ+ 2
,QQ2 3
$strQQ4 :
}QQ; <
}RR 
,RR 
newSS 
ApiScopeSS 
{TT 
NameUU 
=UU 
$strUU 1
,UU1 2
DisplayNameVV 
=VV  !
$strVV" J
,VVJ K

UserClaimsWW 
=WW  
{WW! "
$strWW# )
,WW) *
$strWW+ 2
,WW2 3
$strWW4 :
}WW; <
}XX 
,XX 
newYY 
ApiScopeYY 
{ZZ 
Name[[ 
=[[ 
$str[[ *
,[[* +
DisplayName\\ 
=\\  !
$str\\" C
,\\C D

UserClaims]] 
=]]  
{]]! "
$str]]# )
,]]) *
$str]]+ 2
}]]3 4
}^^ 
}__ 
;__ 
public`` 
static`` 
IEnumerable`` !
<``! "
Client``" (
>``( )

GetClients``* 4
=>``5 7
newaa	 
Listaa 
<aa 
Clientaa 
>aa 
{bb 
newcc 
Clientcc 
{dd 

ClientNameee 
=ee  
$stree! 5
,ee5 6
ClientIdff 
=ff 
$strff E
,ffE F
AllowedGrantTypeshh %
=hh& '

GrantTypeshh( 2
.hh2 35
)ResourceOwnerPasswordAndClientCredentialshh3 \
,hh\ ]
AccessTokenTypeii #
=ii$ %
AccessTokenTypeii& 5
.ii5 6
Jwtii6 9
,ii9 :
AccessTokenLifetimejj '
=jj( )
$numjj* .
,jj. /!
IdentityTokenLifetimekk )
=kk* +
$numkk, 0
,kk0 1,
 UpdateAccessTokenClaimsOnRefreshll 4
=ll5 6
truell7 ;
,ll; <'
SlidingRefreshTokenLifetimemm /
=mm0 1
$nummm2 4
,mm4 5
AllowOfflineAccessnn &
=nn' (
truenn) -
,nn- ."
RefreshTokenExpirationoo *
=oo+ ,
TokenExpirationoo- <
.oo< =
Absoluteoo= E
,ooE F
RefreshTokenUsagepp %
=pp& '

TokenUsagepp( 2
.pp2 3
OneTimeOnlypp3 >
,pp> ?"
AlwaysSendClientClaimsqq *
=qq+ ,
trueqq- 1
,qq1 2
Enabledrr 
=rr 
truerr "
,rr" #
RedirectUrisss  
=ss! "
newss# &
Listss' +
<ss+ ,
stringss, 2
>ss2 3
(ss3 4
)ss4 5
{tt 
$struu ?
}vv 
,vv "
PostLogoutRedirectUrisww *
=ww+ ,
newww- 0
Listww1 5
<ww5 6
stringww6 <
>ww< =
(ww= >
)ww> ?
{xx 
$stryy I
}zz 
,zz 
ClientSecrets{{ !
={{! "
new{{$ '
List{{( ,
<{{, -
Secret{{- 3
>{{3 4
{{{5 6
new{{7 :
Secret{{; A
({{A B
$str{{B P
.{{P Q
Sha256{{Q W
({{W X
){{X Y
){{Y Z
}{{[ \
,{{\ ]
AllowedScopes|| !
=||" #
{||$ %#
IdentityServerConstants}} /
.}}/ 0
StandardScopes}}0 >
.}}> ?
OpenId}}? E
,}}E F#
IdentityServerConstants~~ /
.~~/ 0
StandardScopes~~0 >
.~~> ?
Profile~~? F
,~~F G#
IdentityServerConstants /
./ 0
StandardScopes0 >
.> ?
Email? D
,D E%
IdentityServerConstants
ÄÄ /
.
ÄÄ/ 0
StandardScopes
ÄÄ0 >
.
ÄÄ> ?
OfflineAccess
ÄÄ? L
,
ÄÄL M
$str
ÅÅ &
,
ÅÅ& '
$str
ÇÇ ,
,
ÇÇ, -
$str
ÉÉ .
,
ÉÉ. /
$str
ÑÑ '
,
ÑÑ' (
$str
ÖÖ 
}
ÜÜ 
}
áá 
}
àà 
;
àà 
}
ââ 
}ää Ó	
gC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\Helpers\IdentityExtensions.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

static 
class .
"AppIdentityServerBuilderExtensions :
{ 
public 
static "
IIdentityServerBuilder ,
AddAppUserStore- <
(< =
this= A"
IIdentityServerBuilderB X
builderY `
)` a
{ 	
builder		 
.		 
Services		 
.		 
AddSingleton		 )
<		) *
IUserRepository		* 9
,		9 :
UserRepository		; I
>		I J
(		J K
)		K L
;		L M
builder

 
.

 
AddProfileService

 %
<

% &
AppProfileService

& 7
>

7 8
(

8 9
)

9 :
;

: ;
builder 
. %
AddResourceOwnerValidator -
<- .-
!AppResourceOwnerPasswordValidator. O
>O P
(P Q
)Q R
;R S
return 
builder 
; 
} 	
} 
} —

TC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\Program.cs
	namespace

 	
COVID19Tracker


 
.

 
Auth

 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} ª
TC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\Startup.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

class 
Startup 
{		 
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddIdentityServer &
(& '
x' (
=>) +
{ 
x 
. 
	IssuerUri 
= 
$str $
;$ %
} 
) 
. (
AddInMemoryIdentityResources +
(+ ,
Config, 2
.2 3 
GetIdentityResources3 G
)G H
. #
AddInMemoryApiResources &
(& '
Config' -
.- .
GetApiResources. =
)= >
.  
AddInMemoryApiScopes #
(# $
Config$ *
.* +
GetApiScopes+ 7
)7 8
. 
AddInMemoryClients !
(! "
Config" (
.( )

GetClients) 3
)3 4
. )
AddDeveloperSigningCredential ,
(, -
)- .
. 
AddAppUserStore 
( 
)  
;  !
} 	
public 
void 
	Configure 
( 
IApplicationBuilder 1
app2 5
,5 6
IWebHostEnvironment7 J
envK N
)N O
{ 	
if 
( 
env 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. %
UseDeveloperExceptionPage -
(- .
). /
;/ 0
} 
app"" 
."" 
UseIdentityServer"" !
(""! "
)""" #
;""# $
},, 	
}-- 
}.. Å 
kC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\UserServices\AppProfileService.cs
	namespace		 	
COVID19Tracker		
 
.		 
Auth		 
{

 
public 

class 
AppProfileService "
:# $
IProfileService% 4
{ 
	protected 
readonly 
ILogger "
Logger# )
;) *
	protected 
readonly 
IUserRepository *
_userRepository+ :
;: ;
public 
AppProfileService  
(  !
IUserRepository! 0
userRepository1 ?
,? @
ILoggerA H
<H I
AppProfileServiceI Z
>Z [
logger\ b
)b c
{ 	
_userRepository 
= 
userRepository ,
;, -
Logger 
= 
logger 
; 
} 	
public 
async 
Task 
GetProfileDataAsync -
(- .%
ProfileDataRequestContext. G
contextH O
)O P
{ 	
var 
sub 
= 
context 
. 
Subject %
.% &
GetSubjectId& 2
(2 3
)3 4
;4 5
Logger 
. 
LogDebug 
( 
$str	 Ü
,
Ü á
context 
. 
Subject 
.  
GetSubjectId  ,
(, -
)- .
,. /
context 
. 
Client 
. 

ClientName )
??* ,
context- 4
.4 5
Client5 ;
.; <
ClientId< D
,D E
context   
.   
RequestedClaimTypes   +
,  + ,
context!! 
.!! 
Caller!! 
)!! 
;!!  
var## 
user## 
=## 
await## 
_userRepository## ,
.##, -
FindBySubjectId##- <
(##< =
context##= D
.##D E
Subject##E L
.##L M
GetSubjectId##M Y
(##Y Z
)##Z [
)##[ \
;##\ ]
var%% 
claims%% 
=%% 
new%% 
List%% !
<%%! "
Claim%%" '
>%%' (
{&& 
new'' 
Claim'' 
('' 
$str''  
,''  !
$str''" )
)'') *
,''* +
new(( 
Claim(( 
((( 
$str((  
,((  !
$str((" (
)((( )
,(() *
new)) 
Claim)) 
()) 
$str)) $
,))$ %
user))& *
.))* +
UserName))+ 3
)))3 4
,))4 5
new** 
Claim** 
(** 
$str** !
,**! "
user**# '
.**' (
Email**( -
)**- .
}++ 
;++ 
context-- 
.-- 
IssuedClaims--  
=--! "
claims--# )
;--) *
}.. 	
public00 
async00 
Task00 
IsActiveAsync00 '
(00' (
IsActiveContext00( 7
context008 ?
)00? @
{11 	
var22 
sub22 
=22 
context22 
.22 
Subject22 %
.22% &
GetSubjectId22& 2
(222 3
)223 4
;224 5
var33 
user33 
=33 
await33 
_userRepository33 ,
.33, -
FindBySubjectId33- <
(33< =
context33= D
.33D E
Subject33E L
.33L M
GetSubjectId33M Y
(33Y Z
)33Z [
)33[ \
;33\ ]
context44 
.44 
IsActive44 
=44 
user44 #
!=44$ &
null44' +
;44+ ,
}55 	
}66 
}77 Í
{C:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\UserServices\AppResourceOwnerPasswordValidator.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

class -
!AppResourceOwnerPasswordValidator 2
:3 4+
IResourceOwnerPasswordValidator5 T
{ 
private		 
readonly		 
IUserRepository		 (
_userRepository		) 8
;		8 9
public -
!AppResourceOwnerPasswordValidator 0
(0 1
IUserRepository1 @
userRepositoryA O
)O P
{ 	
_userRepository 
= 
userRepository ,
;, -
} 	
public 
Task 
ValidateAsync !
(! "2
&ResourceOwnerPasswordValidationContext" H
contextI P
)P Q
{ 	
if 
( 
_userRepository 
.  
ValidateCredentials  3
(3 4
context4 ;
.; <
UserName< D
,D E
contextF M
.M N
PasswordN V
)V W
)W X
{ 
var 
user 
= 
_userRepository *
.* +
FindByUsername+ 9
(9 :
context: A
.A B
UserNameB J
)J K
;K L
context 
. 
Result 
=  
new! $!
GrantValidationResult% :
(: ;
user; ?
.? @
	SubjectId@ I
,I J
OidcConstantsK X
.X Y!
AuthenticationMethodsY n
.n o
Passwordo w
)w x
;x y
} 
return 
Task 
. 

FromResult "
(" #
$num# $
)$ %
;% &
} 	
} 
} ó
aC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\UserServices\AppUser.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

class 
AppUser 
{ 
public 
string 
	SubjectId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
}		 
}

 ¬
iC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\UserServices\IUserRepository.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

	interface 
IUserRepository $
{ 
bool 
ValidateCredentials  
(  !
string! '
username( 0
,0 1
string2 8
password9 A
)A B
;B C
Task		 
<		 
AppUser		 
>		 
FindBySubjectId		 %
(		% &
string		& ,
	subjectId		- 6
)		6 7
;		7 8
AppUser 
FindByUsername 
( 
string %
username& .
). /
;/ 0
} 
} õ
hC:\Users\User\Documents\GitHub\Backend\COVID19Tracker\COVID19Tracker.Auth\UserServices\UserRepository.cs
	namespace 	
COVID19Tracker
 
. 
Auth 
{ 
public 

class 
UserRepository 
:  !
IUserRepository" 1
{		 
private

 
readonly

 
List

 
<

 
AppUser

 %
>

% &
_users

' -
=

. /
new

0 3
List

4 8
<

8 9
AppUser

9 @
>

@ A
{ 	
new 
AppUser 
{ 
	SubjectId 
= 
Guid 
.  
NewGuid  '
(' (
)( )
.) *
ToString* 2
(2 3
)3 4
.4 5
ToUpper5 <
(< =
)= >
,> ?
UserName 
= 
$str %
,% &
Password 
= 
$str &
,& '
Email 
= 
$str 4
} 
} 	
;	 

public 
bool 
ValidateCredentials '
(' (
string( .
username/ 7
,7 8
string9 ?
password@ H
)H I
{ 	
var 
user 
= 
FindByUsername %
(% &
username& .
). /
;/ 0
if 
( 
user 
!= 
null 
) 
{ 
return 
user 
. 
Password $
.$ %
Equals% +
(+ ,
password, 4
)4 5
;5 6
} 
return 
false 
; 
} 	
public 
Task 
< 
AppUser 
> 
FindBySubjectId ,
(, -
string- 3
	subjectId4 =
)= >
{   	
var!! 
list!! 
=!! 
_users!! 
.!! 
FirstOrDefault!! ,
(!!, -
x!!- .
=>!!/ 1
x!!2 3
.!!3 4
	SubjectId!!4 =
==!!> @
	subjectId!!A J
)!!J K
;!!K L
return"" 
Task"" 
."" 

FromResult"" "
(""" #
list""# '
)""' (
;""( )
}## 	
public%% 
AppUser%% 
FindByUsername%% %
(%%% &
string%%& ,
username%%- 5
)%%5 6
{&& 	
return'' 
_users'' 
.'' 
FirstOrDefault'' (
(''( )
x'') *
=>''+ -
x''. /
.''/ 0
UserName''0 8
.''8 9
Equals''9 ?
(''? @
username''@ H
,''H I
StringComparison''J Z
.''Z [
OrdinalIgnoreCase''[ l
)''l m
)''m n
;''n o
}(( 	
})) 
}** 