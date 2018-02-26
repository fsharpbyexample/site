---
layout: post
title:  "Welcome to Jekyll!"
date:   2018-02-27 00:14:20 +0700
categories: jekyll update
---
{% capture code_comment_one %}
This is a comment alongside the code.
{% endcapture %}

{% capture code_one %}
def print_hi(name)
  puts "Hi, #{name}"
print_hi('Tom')
#=> prints 'Hi, Tom' to STDOUT.
{% endcapture %}

{% include code.html code=code_one comment=code_comment_one %}
