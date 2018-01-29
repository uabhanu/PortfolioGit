using LitJson;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class BhanuJSon : MonoBehaviour 
{
	public Bhanu bhanu = new Bhanu(false , 32 , "7th Dec 1983" , "Bhanu Upadhyayula");

	JsonData bhanuJSon;
	MongoClient mongoClient;
	MongoCollection mongoCollection;
	MongoDatabase mongoDB;
	MongoServer mongoServer;

	public void Write() 
	{
		File.WriteAllText(Application.dataPath + "/Bhanu.json" , bhanuJSon.ToString());
	}

	void Start() 
	{
		bhanuJSon = JsonMapper.ToJson(bhanu);
		mongoClient = new MongoClient(new MongoUrl("mongodb://localhost"));
		mongoServer = mongoClient.GetServer();
		mongoServer.Connect();
		mongoDB = mongoServer.GetDatabase("test");
		mongoCollection = mongoDB.GetCollection("Orders");
	}
}

public class Bhanu
{
	public bool dead;
	public int age;
	public string DOB , name;

	public Bhanu(bool dead , int age , string DOB , string name)
	{
		this.dead = dead;
		this.age = age;
		this.DOB = DOB;
		this.name = name;
	}
}
