- title : Machine Learning With F#
- description : Machine Learning With F#. Denver Dev Day (June 24, 2016)
- author : Grigoriy Belenkiy (@grishace)
- theme : simple
- transition : zoom

***
- data-background : images/sponsors.png
- data-background-transition : none

' Sponsors slide (required by organizators)

***

### Machine Learning With F#

![Machine Learning With F#](./images/number5.jpg)

<!-- Image by TriStar Pictures, 1988 -->

<small>Grigoriy Belenkiy<br/>
Software engineer, S&amp;P Global<br/>
[@grishace](https://twitter.com/grishace)<br/>
<br/>
//denver/dev/day<br/>
June 24, 2016</small>

***

### Agenda

- Machine Learning
- Toolkit
- Linear regression
- Logistic regression
- Clustering
- Neural networks

***

### Machine Learning

- explores the study and construction of algorithms that can learn from and make predictions on data
- focuses on prediction, based on known properties learned from the training data
- spam filtering, OCR, search engines, and computer vision

' Started in 50's, but abandoned and emerged back in 80's-90's
' Traditionally developers, when faced with a problem, develop and algorithm and write code. Certain classes of problems, however, do not lend themselves to this approach. With machine learning, the developer instead supplies relevant data to the machine and allows the computer to create the appropriate algorithm.
' Supervised learning is the branch of machine learning that deals primarily with prediction. Given examples, supervised learning algorithms create models that generalize the decision making process. In essence, the machine learns from the past in order to accurately predict the future.
' Unsupervised learning is the branch of machine learning that strives to understand the structure of data. This data, unlike supervised learning, does not have a predefined outcome that requires prediction but is vast enough to require a principled approach to either visual or physical compression.

---

### Toolkit 

- R (+R Tools for Visual Studio, SQL Server 2016 R Services)
- MATLAB (+GNU Octave)
- Python (scikit-learn, pandas, numpy, Jupyter notebook)

---

### BIG players

- Azure ML
- TensorFlow
- FBLearner Flow
- Amazon Machine Learning(AWS)

---

### .NET Framework

- Accord.NET
- Math.NET Numerics
- Numl
- Encog

' Accord.NET - more than just ML
' Math.NET - numerical computations in science, engineering and every day use. Covered topics include special functions, linear algebra, probability models, random numbers, interpolation, integration, regression, optimization problems and more 
' Numl -
' Encog - C#/Java, CUDA support

***

### Supervised Learning

<ul>
<span class="fragment"><li>Linear&#160;regression</li></span>
<span class="fragment"><li>Logistic&#160;regression</li></span>
</ul>

---

### Linear Regression


' linear regression is an approach for modeling the relationship between a scalar dependent variable y and one or more explanatory variables (or independent variables) denoted X. The case of one explanatory variable is called simple linear regression. For more than one explanatory variable, the process is called multiple linear regression.
' Ordinary least squares (OLS) is the simplest and thus most common estimator

---

### Logistic Regression

' Logistic regression is a regression model where the dependent variable (DV) is categorical.
' measures the relationship between the categorical dependent variable and one or more independent variables by estimating probabilities
' was developed by statistician David Cox in 1958
' used widely in many fields, including the medical and social sciences
' a business application would be to predict the likelihood of a homeowner defaulting on a mortgage

***

### Unsupervised Learning

- K-Means

' Assign each observation to the cluster whose mean yields the least within-cluster sum of squares 
' Calculate the new means to be the centroids of the observations in the new clusters
'
' result often fails to separate the three Iris species contained in the data set
' The number of clusters k is an input parameter: an inappropriate choice of k may yield poor results
' The term "k-means" was first used by James MacQueen in 1967, though the idea goes back to Hugo Steinhaus in 1957.

***

### Supervised Learning (continued)

- Neural Networks

' Artificial - debatable that does the same as human brain
' Multi-layer networks use a variety of learning techniques, the most popular being back-propagation. Here, the output values are compared with the correct answer to compute the value of some predefined error-function. By various techniques, the error is then fed back through the network. Using this information, the algorithm adjusts the weights of each connection in order to reduce the value of the error function by some small amount. After repeating this process for a sufficiently large number of training cycles, the network will usually converge to some state where the error of the calculations is small
' 1943 > 1954 (computational) > 1975 (back propagation) > 2000's (more improvements)

---

### XOR

<table>
  <tr>
     <td></td>
     <td>0</td>
     <td>1</td>
  </tr>
  <tr>
     <td>0</td>
     <td>0</td>
     <td>1</td>
  </tr>
  <tr>
     <td>1</td>
     <td>1</td>
     <td>0</td>
  </tr>
</table>

---

### XOR

![XOR](./images/XOR.png)

***

### Coursera

- Machine Learning [https://www.coursera.org/learn/machine-learning](https://www.coursera.org/learn/machine-learning)
- Введение в машинное обучение [https://www.coursera.org/learn/vvedenie-mashinnoe-obuchenie](https://www.coursera.org/learn/vvedenie-mashinnoe-obuchenie)

' Specializations

---

### Books

<table class="no-borders-table"><tr>
<td width="33%"><a href="https://www.amazon.com/Machine-Learning-Projects-NET-Developers/dp/1430267674/" title="Machine Learning Projects for .NET Developers"><img alt="Machine Learning Projects for .NET Developers" src="./images/51t7LqurxML._SX348_BO1,204,203,200_.jpg"/></a></td>
<td width="33%"><a href="https://www.amazon.com/Mastering-Machine-Learning-Jamie-Dixon/dp/1785888404/" title="Mastering .NET Machine Learning"><img alt="Mastering .NET Machine Learning" src="./images/51AZ868R9xL._SX404_BO1,204,203,200_.jpg"/></a></td>
<td width="33%"><a href="https://www.syncfusion.com/resources/techportal/details/ebooks/machine" title="Machine Learning Using C# Succinctly"><img alt="Machine Learning Using C# Succinctly" src="./images/machine_learning_Succinctly.png"/></a></td>
</tr>
<tr><td>
<small><h3>Machine Learning Projects for .NET Developers</h3>
<h4>by Mathias Brandewinder</h4></small></td>

<td>
<small><h3>Mastering .NET Machine Learning</h3>
<h4>by Jamie Dixon </h4></small></td>

<td>
<small><h3>Machine Learning Using C# Succinctly</h3>
<h4>by James McCaffrey</h4></small></td>
</tr></table>

***

[![https://github.com/grishace/ddd-ml](./images/qrcode.png)](https://github.com/grishace/ddd-ml)<br/>
[https://github.com/grishace/ddd-ml](https://github.com/grishace/ddd-ml)
