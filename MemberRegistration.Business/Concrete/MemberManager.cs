using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }
        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {
            CheckIfMemberExist(member);
            CheckIfUserValidFromKps(member);
        }

        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.VallidateUser(member) == false)
            {
                throw new Exception("Kullanıcı doğrulaması geçersiz");
            }
            _memberDal.Add(member);
        }

        private void CheckIfMemberExist(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
            {
                throw new Exception("Bu kullanıcı zaten kayıtlı");
            }
        }
    }
}
