<div class="flex w-full flex-col gap-1 empty:hidden first:pt-[3px]">
<h2 data-start="107" data-end="148" class=""><strong data-start="110" data-end="148">📌 Project Overview: User Blog API</strong></h2>

<p data-start="149" data-end="546" class="">This is a <strong data-start="159" data-end="174">backend API</strong> built using <strong data-start="187" data-end="202">.NET Core 8</strong> that provides authentication and blog article management. The API allows users to <strong data-start="308" data-end="355">register, log in, and manage their profiles</strong>, while also enabling them to <strong data-start="385" data-end="442">create, read, update, and delete (CRUD) blog articles</strong>. The authentication system is based on <strong data-start="482" data-end="506">JWT (JSON Web Token)</strong>, and <strong data-start="512" data-end="521">MySQL</strong> is used as the database.</p>

<hr data-start="548" data-end="551" class="">

<h2 data-start="553" data-end="597" class=""><strong data-start="556" data-end="597">⚙️ Technologies &amp; Configurations Used</strong></h2>

<div class="overflow-x-auto contain-inline-size"><table data-start="598" data-end="1119" node="[object Object]"><thead data-start="598" data-end="648"><tr data-start="598" data-end="648"><th data-start="598" data-end="619">Feature</th><th data-start="619" data-end="648">Technology Used</th></tr></thead><tbody data-start="698" data-end="1119"><tr data-start="698" data-end="734"><td><strong data-start="700" data-end="713">Framework</strong></td><td>.NET Core 8</td></tr><tr data-start="735" data-end="765"><td><strong data-start="737" data-end="749">Database</strong></td><td>MySQL</td></tr><tr data-start="766" data-end="837"><td><strong data-start="768" data-end="775">ORM</strong></td><td>Entity Framework Core (Database-First Approach)</td></tr><tr data-start="838" data-end="883"><td><strong data-start="840" data-end="858">Authentication</strong></td><td>JWT (JSON Web Token)</td></tr><tr data-start="884" data-end="936"><td><strong data-start="886" data-end="898">Security</strong></td><td>BCrypt for password hashing</td></tr><tr data-start="937" data-end="997"><td><strong data-start="939" data-end="960">Database Provider</strong></td><td>Pomelo.EntityFrameworkCore.MySql</td></tr><tr data-start="998" data-end="1059"><td><strong data-start="1000" data-end="1014">Middleware</strong></td><td>Authentication &amp; Authorization using JWT</td></tr><tr data-start="1060" data-end="1119"><td><strong data-start="1062" data-end="1086">Dependency Injection</strong></td><td>Built-in .NET Core DI system</td></tr></tbody></table></div>

<hr data-start="1607" data-end="1610" class="">

<h2 data-start="1612" data-end="1635" class=""><strong data-start="1615" data-end="1635">📜 API Endpoints</strong></h2>

<h3 data-start="1636" data-end="1667" class=""><strong data-start="1640" data-end="1667">🛡️ Authentication APIs</strong></h3>

<div class="overflow-x-auto contain-inline-size"><table data-start="1668" data-end="1951" node="[object Object]"><thead data-start="1668" data-end="1719"><tr data-start="1668" data-end="1719"><th data-start="1668" data-end="1674">API</th><th data-start="1674" data-end="1688">HTTP Method</th><th data-start="1688" data-end="1702">Description</th><th data-start="1702" data-end="1719">Auth Required</th></tr></thead><tbody data-start="1771" data-end="1951"><tr data-start="1771" data-end="1828"><td><code data-start="1773" data-end="1791">/api/v1/register</code></td><td><code data-start="1794" data-end="1800">POST</code></td><td>Register a new user</td><td>❌</td></tr><tr data-start="1829" data-end="1894"><td><code data-start="1831" data-end="1846">/api/v1/login</code></td><td><code data-start="1849" data-end="1855">POST</code></td><td>Authenticate user &amp; return JWT</td><td>❌</td></tr><tr data-start="1895" data-end="1951"><td><code data-start="1897" data-end="1918">/api/v1/get-profile</code></td><td><code data-start="1921" data-end="1926">GET</code></td><td>Get user profile</td><td>✅</td></tr></tbody></table></div>

<h3 data-start="1953" data-end="1977" class=""><strong data-start="1957" data-end="1977">📝 Articles APIs</strong></h3>
<div class="overflow-x-auto contain-inline-size"><table data-start="1978" data-end="2387" node="[object Object]"><thead data-start="1978" data-end="2029"><tr data-start="1978" data-end="2029"><th data-start="1978" data-end="1984">API</th><th data-start="1984" data-end="1998">HTTP Method</th><th data-start="1998" data-end="2012">Description</th><th data-start="2012" data-end="2029">Auth Required</th></tr></thead><tbody data-start="2081" data-end="2387"><tr data-start="2081" data-end="2134"><td><code data-start="2083" data-end="2101">/api/v1/articles</code></td><td><code data-start="2104" data-end="2109">GET</code></td><td>Get all articles</td><td>❌</td></tr><tr data-start="2135" data-end="2205"><td><code data-start="2137" data-end="2160">/api/v1/articles/{id}</code></td><td><code data-start="2163" data-end="2168">GET</code></td><td>Get a specific article by ID</td><td>❌</td></tr><tr data-start="2206" data-end="2264"><td><code data-start="2208" data-end="2226">/api/v1/articles</code></td><td><code data-start="2229" data-end="2235">POST</code></td><td>Create a new article</td><td>✅</td></tr><tr data-start="2265" data-end="2324"><td><code data-start="2267" data-end="2290">/api/v1/articles/{id}</code></td><td><code data-start="2293" data-end="2298">PUT</code></td><td>Update an article</td><td>✅</td></tr><tr data-start="2325" data-end="2387"><td><code data-start="2327" data-end="2350">/api/v1/articles/{id}</code></td><td><code data-start="2353" data-end="2361">DELETE</code></td><td>Delete an article</td><td>✅</td></tr></tbody></table></div>

<hr data-start="2496" data-end="2499" class="" style="">

<h2 data-start="2501" data-end="2526" class=""><strong data-start="2504" data-end="2526">📄 Database Script</strong></h2>

<p data-start="2527" data-end="2621" class="">A <strong data-start="2529" data-end="2554">MySQL database script</strong> is included in the <strong data-start="2574" data-end="2600">repository root folder</strong> with the filename:</p>

<p data-start="2623" data-end="2659" class="">📌 <strong data-start="2626" data-end="2657"><code data-start="2628" data-end="2655">MySQL_Database_Script.sql</code></strong></p>
