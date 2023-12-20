# -*- coding: utf-8 -*-
"""
Created on Sat Dec 16 14:39:29 2023

@author: HoChePing
"""

import os
import glob

def find_json_files(directory):
    # 構造一個包含所有子資料夾的搜尋路徑
    path_pattern = os.path.join(directory, '**', 'UserDataLocation.json')
    
    # 使用 glob.glob 進行搜尋，並設置 recursive=True 來包含所有子資料夾
    files = glob.glob(path_pattern, recursive=True)

    return files

# 指定要搜尋的資料夾路徑
directory = 'path/to/your/folder'  # 請將此處替換為您的資料夾路徑

# 呼叫函數並列印結果
found_files = find_json_files(directory)
for file in found_files:
    print(file)